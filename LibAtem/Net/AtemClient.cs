using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using log4net;
using LibAtem.Commands;

namespace LibAtem.Net
{
    public class AtemClient
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AtemClient));

        private readonly UdpClient _client;
        private readonly IPEndPoint _remoteEp;

        private readonly AtemClientConnection _connection;
        private Timer _pingTimer;

        public delegate void CommandHandler(object sender, IReadOnlyList<ICommand> commands);
        public delegate void ConnectedHandler(object sender);
        public delegate void DisconnectedHandler(object sender);

        public event CommandHandler OnReceive;
        public event ConnectedHandler OnConnection;
        public event DisconnectedHandler OnDisconnect;

        public AtemClient(string address)
        {
            _remoteEp = new IPEndPoint(IPAddress.Parse(address), 9910);
            _client = new UdpClient(new IPEndPoint(IPAddress.Any, 0));

            _connection = new AtemClientConnection(_remoteEp, new Random().Next(65535));
            _connection.OnDisconnect += sender => OnDisconnect?.Invoke(this);

            StartReceiving();
            SendHandshake();
            StartPingTimer();
        }

        public void StartPingTimer()
        {
            _pingTimer = new Timer(o =>
            {
                Socket socket = _client.Client;
                if (_connection.HasTimedOut)
                    return;

                _connection.SendPing(ref socket);
            }, null, 0, AtemConstants.PingInterval);
        }

        private void SendHandshake()
        {
            // send handshake back
            byte[] handshake =
            {
                0x10, 0x14, // flags + length
                (byte) (_connection.SessionId << 8), (byte) _connection.SessionId, // session id
                0x00, 0x00, // acked pkt id
                0x00, 0x00, // unknown
                0x00, 0x68, // unknown2
                0x00, 0x00, // server pkt id
                0x01, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00
            };

            _client.SendAsync(handshake, handshake.Length, _remoteEp);
        }

        private void StartReceiving()
        {
            var thread = new Thread(async () =>
            {
                while (true)
                {
                    try
                    {
                        UdpReceiveResult res = await _client.ReceiveAsync();

                        ReceivedPacket packet = new ReceivedPacket(res.Buffer);

                        if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.Handshake) && OnConnection != null)
                            OnConnection(this);

                        _connection.Receive(_client.Client, packet, cmds =>
                        {
                            Log.DebugFormat("Recieved {0} commands", cmds.Count);

                            if (OnReceive != null)
                                OnReceive(this, cmds);
                        });
                    }
                    catch (SocketException)
                    {
                        Log.ErrorFormat("Socket Exception");
                    }
                }
            });
            thread.Start();
        }

        public void SendCommand(ICommand cmd)
        {
            _connection.QueueCommand(cmd);
        }

        public void Dispose()
        {
            // TODO

            if (_pingTimer != null)
                _pingTimer.Dispose();
        }
    }
}
