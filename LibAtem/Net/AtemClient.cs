using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using LibAtem.Commands;
using LibAtem.Net.DataTransfer;

namespace LibAtem.Net
{
    public class AtemClient : IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AtemClient));

        private readonly UdpClient _client;
        private readonly IPEndPoint _remoteEp;

        private readonly AtemClientConnection _connection;
        private Timer _pingTimer;
        private Thread _sendThread;

        public delegate void CommandHandler(object sender, IReadOnlyList<ICommand> commands);
        public delegate void ConnectedHandler(object sender);
        public delegate void DisconnectedHandler(object sender);

        public event CommandHandler OnReceive;
        public event ConnectedHandler OnConnection;
        public event DisconnectedHandler OnDisconnect;

        public DataTransferManager DataTransfer { get; }

        public AtemClient(string address, bool autoConnect=true)
        {
            _remoteEp = new IPEndPoint(IPAddress.Parse(address), 9910);
            _client = new UdpClient(new IPEndPoint(IPAddress.Any, 0));

            _connection = new AtemClientConnection(_remoteEp, new Random().Next(65535));
            _connection.OnDisconnect += sender => OnDisconnect?.Invoke(this);

            DataTransfer = new DataTransferManager(_connection);

            if (autoConnect)
                Connect();
        }

        public bool Connect()
        {
            // Check if connect has already been called
            if (_pingTimer != null)
                return false;

            StartReceiving();
            SendHandshake();
            StartPingTimer();
            StartSendingTimer();
            return true;
        }

        private void StartPingTimer()
        {
            _pingTimer = new Timer(o =>
            {
                if (_connection.HasTimedOut)
                    return;

                _connection.QueuePing();
            }, null, 0, AtemConstants.PingInterval);
        }

        private void StartSendingTimer()
        {
            _sendThread = new Thread(o =>
            {
                while (!_connection.HasTimedOut)
                {
                    _connection.TrySendQueued(_client.Client);
                    Task.Delay(5).Wait();
                }
            });
            _sendThread.Start();
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

            Log.DebugFormat("Starting handshake");
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

                        if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.Handshake))
                        {
                            Log.DebugFormat("Completed handshake");
                            OnConnection?.Invoke(this);
                            _connection.SendAck(_client.Client, packet.PacketId, true);
                            continue;
                        }

                        _connection.Receive(_client.Client, packet, cmds =>
                        {
                            Log.DebugFormat("Recieved {0} commands", cmds.Count);

                            cmds = TryHandleDataTransfer(cmds);
                            Log.DebugFormat("{0} commands to be handle by user code", cmds.Count);

                            OnReceive?.Invoke(this, cmds);
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

        private IReadOnlyList<ICommand> TryHandleDataTransfer(IReadOnlyList<ICommand> cmds)
        {
            return cmds.Where(c => !DataTransfer.HandleCommand(c)).ToList();
        }

        public void SendCommand(ICommand cmd)
        {
            _connection.QueueCommand(cmd);
        }

        public void Dispose()
        {
            // TODO

            DataTransfer?.Dispose();
            
            _pingTimer?.Dispose();
        }
    }
}

