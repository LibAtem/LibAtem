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
        private Timer _timeoutTimer;
        private Timer _ackTimer;
        private Thread _sendThread;
        private Thread _handleThread;
        private bool _run;

        public delegate void CommandHandler(object sender, IReadOnlyList<ICommand> commands);
        public delegate void ConnectedHandler(object sender);
        public delegate void DisconnectedHandler(object sender);

        public event CommandHandler OnReceive;
        public event ConnectedHandler OnConnection;
        public event DisconnectedHandler OnDisconnect;

        public event AtemConnection.PacketHandler OnReceivePacket
        {
            add => _connection.OnReceivePacket += value;
            remove => _connection.OnReceivePacket -= value;
        }

        public DataTransferManager DataTransfer { get; }

        public ProtocolVersion? ConnectionVersion => _connection.ConnectionVersion;

        public AtemClient(string address, bool autoConnect = true)
        {
            _remoteEp = new IPEndPoint(IPAddress.Parse(address), 9910);
            _client = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
            _client.Client.ReceiveBufferSize = 1500 * 50; // TODO tweak this value

            _connection = new AtemClientConnection(_remoteEp, new Random().Next(32767));
            _connection.OnDisconnect += sender => OnDisconnect?.Invoke(this);
            _connection.OnInitComplete += sender => OnConnection?.Invoke(this);

            DataTransfer = new DataTransferManager(_connection);

            if (autoConnect)
                Connect();
        }

        public bool Connect()
        {
            // Check if connect has already been called
            if (_run)
                return false;

            _run = true;
            StartReceiving();
            SendHandshake();
            StartSendingTimer();
            StartHandleThread();
            StartTimeoutTimer();
            StartAckTimer();
            return true;
        }

        private bool Reconnect()
        {
            try
            {
                lock (_connection)
                {
                    if (!_connection.HasTimedOut)
                        return false;

                    if (_connection.ConnectionVersion != null)
                        OnDisconnect?.Invoke(this);

                    Log.InfoFormat("Attempting Reconnect");
                    _connection.ResetConnStatsInfo();
                    _connection.SessionId = new Random().Next(32767);
                    SendHandshake();
                    StartSendingTimer();
                }
            }
            catch (SocketException e)
            {
                Log.DebugFormat("Failed to reconnect: {0}", e);
            }

            return true;
        }

        private void StartTimeoutTimer()
        {
            _timeoutTimer = new Timer(o =>
            {
                if (!_connection.HasTimedOut)
                    return;

                Reconnect();
            }, null, 0, AtemConstants.TimeoutInterval);
        }

        private void StartAckTimer()
        {
            _ackTimer = new Timer(o =>
            {
                if (!_connection.HasTimedOut)
                    return;

                _connection.SendAckNow(_client.Client);
            }, null, 0, AtemConstants.AckInterval);
        }

        private void StartSendingTimer()
        {
            _sendThread = new Thread(o =>
            {
                while (!_connection.HasTimedOut)
                {
                    if (!_connection.TrySendQueued(_client.Client))
                        Thread.Sleep(1);
                }
            });
            _sendThread.Name = "LibAtem.Send";
            _sendThread.IsBackground = true;
            _sendThread.Start();
        }

        private void StartHandleThread()
        {
            _handleThread = new Thread(o =>
            {
                while (_run || _connection.HasCommandsToProcess)
                {
                    List<ICommand> cmds = _connection.GetNextCommands();
                    int rawCount = cmds.Count;

                    cmds = cmds.Where(c => !DataTransfer.HandleCommand(c)).ToList();
                    Log.DebugFormat("Recieved {0} commands. {1} to be handle by user code", rawCount, cmds.Count);

                    if (cmds.Any())
                        OnReceive?.Invoke(this, cmds);
                }
            });
            _handleThread.Name = "LibAtem.Handle";
            _handleThread.IsBackground = true;
            _handleThread.Start();
        }

        private void SendHandshake()
        {
            // send handshake back
            byte[] handshake =
            {
                0x10, 0x14, // flags + length
                (byte) (_connection.SessionId >> 8), (byte) _connection.SessionId, // session id
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
            var thread = new Thread(() =>
            {
                while (_run)
                {
                    try
                    {
                        IPEndPoint ep = _remoteEp;
                        byte[] data = _client.Receive(ref ep);

                        ReceivedPacket packet = new ReceivedPacket(data);

                        if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.Handshake))
                        {
                            Log.DebugFormat("Completed handshake");
                            DataTransfer.Reset();
                            _connection.SendAckNow(_client.Client, true);
                            continue;
                        }

                        // TODO - should this only be allowed once?
                        if (_connection.SessionId != packet.SessionId)
                        {
                            _connection.SessionId = (int)packet.SessionId;
                            Log.InfoFormat("Got new session id: {0}", packet.SessionId);
                        }

                        _connection.Receive(_client.Client, packet);
                    }
                    catch (SocketException)
                    {
                        Log.ErrorFormat("Socket Exception");
                    }
                }
            });
            thread.Name = "LibAtem.Receive";
            thread.IsBackground = true;
            thread.Start();
        }

        public void SendCommand(ICommand cmd)
        {
            _connection.QueueCommand(cmd);
        }

        public void DirectQueueMessage(OutboundMessage msg)
        {
            _connection.QueueMessage(msg);
        }

        public void Dispose()
        {
            // TODO

            DataTransfer?.Dispose();

            _timeoutTimer?.Dispose();
        }

        public bool HasQueuedOutbound()
        {
            return _connection.HasQueuedOutbound();
        }
    }
}

