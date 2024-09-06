using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using log4net;
using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;
using LibAtem.MacroOperations;
using LibAtem.Serialization;
using LibAtem.Util;
using System.Diagnostics;

namespace LibAtem.Net
{
    public abstract class AtemConnection
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AtemConnection));

        private const int TimeOutMilliseonds = 1000;
        private const uint MaxPacketId = 1 << 15; // Atem expects 15 not 16 bits before wrapping
        private const uint MaxInFlight = 32; // TODO - is this wanted? SDK appears to not do it
        private const uint InFlightTimeout = 30;

        public int SessionId { get; internal set; }
        public EndPoint Endpoint { get; }

        private readonly object _lastSentAckLock = new object();
        private DateTime _lastReceivedTime;

        private uint _lastPacketId;
        private uint? _lastReceivedAck;

        private DateTime? _ackWaitingSince;
        private uint? _lastSentAck;
        private uint? _readyToAck;

        private bool _isOpen;

        private ProtocolVersion? _protocolVersion;

        private readonly Queue<OutboundMessage> _messageQueue;
        private readonly List<InFlightMessage> _inFlight;
        private readonly BlockingCollection<ReceivedPacket> _processQueue;

        public delegate void InitCompleteHandler(object sender);
        public delegate void DisconnectHandler(object sender);
        public delegate void PacketHandler(object sender, ReceivedPacket pkt);

        public event InitCompleteHandler OnInitComplete;
        public event DisconnectHandler OnDisconnect;
        public event PacketHandler OnReceivePacket;

        private class InFlightMessage
        {
            public OutboundMessage Message { get; }
            public uint? AckId { get; }
            public DateTime LastSent { get; set; }

            public InFlightMessage(OutboundMessage message, uint? ackId)
            {
                Message = message;
                AckId = ackId;
                LastSent = DateTime.MinValue;
            }
        }

        static AtemConnection()
        {
            AutoSerializeBase.CompilePropertySpecForTypes(CommandManager.GetAllTypes().SelectMany(g => g.Value.Select(t => t.Item2)));
            AutoSerializeBase.CompilePropertySpecForTypes(MacroOpManager.FindAll().Select(m => m.Value.Item2));
        }

        protected AtemConnection(EndPoint endpoint, int sessionId)
        {
            Endpoint = endpoint;
            SessionId = sessionId;
            _lastReceivedTime = DateTime.Now;

            _messageQueue = new Queue<OutboundMessage>();
            _inFlight = new List<InFlightMessage>();
            _processQueue = new BlockingCollection<ReceivedPacket>(new ConcurrentQueue<ReceivedPacket>());
        }

        public bool IsOpened => _isOpen;

        public virtual ProtocolVersion? ConnectionVersion => _protocolVersion;

        public void ResetConnStatsInfo()
        {
            lock (_inFlight)
            {
                lock (_messageQueue)
                {
                    _lastReceivedTime = DateTime.Now;
                    _lastPacketId = 0;
                    _lastReceivedAck = null;
                    _lastSentAck = null;
                    _readyToAck = null;
                    _protocolVersion = null;
                    _inFlight.Clear();
                    _messageQueue.Clear();
                }
            }
        }

        public bool HasTimedOut => GetTimeBetween(_lastReceivedTime, DateTime.Now) > TimeOutMilliseonds;

        private uint IncrementPacketId(uint pktId, uint delta = 1)
        {
            uint newId = pktId + delta;
            return newId >= MaxPacketId ? 0 : newId;
        }

        private uint NextPacketId
        {
            get
            {
                uint pktId = ++_lastPacketId;
                if (pktId >= MaxPacketId)
                    return _lastPacketId = 0;

                return pktId;
            }
        }

        public void QueuePing()
        {
            QueueMessage(new OutboundMessage(OutboundMessage.OutboundMessageType.Ping, new byte[0]));
        }

        public abstract void QueueCommand(ICommand command);

        public void QueueMessage(OutboundMessage msg)
        {
            lock (_messageQueue)
            {
                _messageQueue.Enqueue(msg);
            }
        }

        public void Receive(Socket socket, ReceivedPacket packet)
        {
            try
            {
                if (HasTimedOut)
                    return;

                _lastReceivedTime = DateTime.Now;

                // If we have already acked, then reack 
                if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.AckRequest) && IsPacketCoveredByAck(_readyToAck.GetValueOrDefault(0), packet.PacketId))
                {
                    QueueOrSendAck(socket, packet.PacketId);
                    return;
                }

                // If we have skipped something, then discard
                if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.AckRequest) && packet.PacketId != IncrementPacketId(_readyToAck.GetValueOrDefault(0)))
                {
                    Log.DebugFormat("{0} - Discarding message received out of order Got:{1} Expected:{2}", Endpoint, packet.PacketId, _readyToAck);
                    return;
                }

                // Handle it
                if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.AckRequest))
                {
                    QueueOrSendAck(socket, packet.PacketId);
                }

                Log.DebugFormat("{0} - Command {1}, Length {2}, Session {3:X}, Acked {4}, Packet {5}", Endpoint,
                    packet.CommandCode, packet.PayloadLength, packet.SessionId, packet.AckedId, packet.PacketId);

                if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.AckReply))
                {
                    _isOpen = true;

                    if (!_lastReceivedAck.HasValue || !IsPacketCoveredByAck(_lastReceivedAck.Value, packet.AckedId))
                        _lastReceivedAck = packet.AckedId;
                }
                if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.AckRequest))
                {
                    Log.DebugFormat("{0} - Parsed {1} commands with length {2}", Endpoint, packet.Commands.Count, packet.PayloadLength);

                    _processQueue.Add(packet);
                    OnReceivePacket?.Invoke(this, packet);
                }
                // Note: Handshake is handled elsewhere
                // Note: Unknown, Retransmit both need no action
            }
            catch (ArgumentException)
            {
                //discard as was malformed
            }
        }

        public bool HasCommandsToProcess => _processQueue.Count > 0;

        public List<ICommand> GetNextCommands()
        {
            try
            {
                var result = new List<ICommand>();
                foreach (ParsedCommandSpec rawCmd in _processQueue.Take().Commands)
                {
                    // Don't print full command, if it is really long for performance reasons 
                    string payloadStr = rawCmd.Body.Length > 100 ? "of " + rawCmd.Body.Length + " bytes" : BitConverter.ToString(rawCmd.Body);
                    Log.DebugFormat("{0} - Received command {1} with content {2}", Endpoint, rawCmd.Name, payloadStr);

                    var cmd = CommandParser.Parse(_protocolVersion ?? ProtocolVersion.Minimum, rawCmd);
                    if (cmd is VersionCommand verCmd)
                    {
                        _protocolVersion = verCmd.ProtocolVersion;
                        // TODO - log version info
                    } else if (cmd is InitializationCompleteCommand)
                    {
                        OnInitComplete?.Invoke(this);
                    }
                    result.AddIfNotNull(cmd);

                    if (cmd == null)
                    {
                        Debug.WriteLine($"Received unknown command {rawCmd.Name} with content {payloadStr}");
                    }
                }

                return result;
            }
            catch (ArgumentException)
            {
                //discard as was malformed
                return new List<ICommand>();
            }
        }

        protected internal void SendAckNow(Socket socket, bool forcePacketZero = false)
        {
            uint packetId;
            lock (_lastSentAckLock)
            {
                if (!forcePacketZero && _lastSentAck.HasValue)
                {
                    // Dont send ack if nothing to ack
                    if (!_readyToAck.HasValue)
                        return;

                    // Determine next Id
                    if (_lastSentAck.Value == _readyToAck.Value)
                        return;
                }

                packetId = _readyToAck.GetValueOrDefault(0);
                _ackWaitingSince = null;
            }

            SendMessage(socket, new InFlightMessage(new OutboundMessage(OutboundMessage.OutboundMessageType.Ack, new byte[0]), packetId));
        }

        private void QueueOrSendAck(Socket socket, uint packetId)
        {
            lock (_lastSentAckLock)
            {
                if (!_readyToAck.HasValue || !IsPacketCoveredByAck(_readyToAck.Value, packetId))
                    _readyToAck = packetId;

                // If we have not acked anything yet
                bool shouldSend = !_lastSentAck.HasValue;

                // If too many waiting
                if (_readyToAck.Value - _lastSentAck.GetValueOrDefault(0) >= 16)
                    shouldSend = true;

                if (_ackWaitingSince.HasValue && GetTimeBetween(_ackWaitingSince.Value, DateTime.Now) >= AtemConstants.AckInterval)
                    shouldSend = true;

                if (!shouldSend)
                {
                    _ackWaitingSince = _ackWaitingSince ?? DateTime.Now;
                    return;
                }

                _lastSentAck = _readyToAck.Value;
                _ackWaitingSince = null;
                packetId = _readyToAck.Value;
            }
            SendMessage(socket, new InFlightMessage(new OutboundMessage(OutboundMessage.OutboundMessageType.Ack, new byte[0]), packetId));
        }

        public bool TrySendQueued(Socket socket)
        {
            if (HasTimedOut)
                return false;

            List<InFlightMessage> msgs = ChooseMsg();
            if (msgs == null || !msgs.Any())
                return false;

            foreach (InFlightMessage msg in msgs)
                SendMessage(socket, msg);
            return true;
        }

        private static int GetTimeBetween(DateTime since, DateTime before)
        {
            TimeSpan diff = before - since;
            return diff.Seconds * 1000 + diff.Milliseconds;
        }

        private static bool IsPacketCoveredByAck(uint ackId, uint packetId)
        {
            const int tol = 1 << 8;
            var pktIsShortlyBefore = packetId < ackId && packetId + tol > ackId;
            var pktIsShortlyAfter = packetId > ackId && packetId < ackId + tol;
            var pktIsBeforeWrap = packetId > ackId + tol;

            return packetId == ackId || ((pktIsShortlyBefore || pktIsBeforeWrap) && !pktIsShortlyAfter);
            //return id <= other && id > ((int)other - tol) || id <= other + MaxPacketId && id > other + MaxPacketId - tol || id <= (int)other - MaxPacketId + tol && id > (int)other - MaxPacketId;
        }

        private List<InFlightMessage> ChooseMsg()
        {
            lock (_inFlight)
            {
                if (_lastReceivedAck.HasValue)
                    _inFlight.RemoveAll(m => IsPacketCoveredByAck(_lastReceivedAck.Value, m.Message.PacketId));

                // If any were resent, then dont send anything new
                if (_inFlight.Count > 0)
                {
                    DateTime now = DateTime.Now;
                    if (_inFlight.Any(m => GetTimeBetween(m.LastSent, now) > InFlightTimeout))
                    {
                        List<InFlightMessage> toResend = _inFlight.ToList();
                        Log.WarnFormat("{0} - Resending {1} packets from #{2}", Endpoint, toResend.Count, toResend[0].Message.PacketId);
                        return toResend;
                    }
                }

                if (_inFlight.Count >= MaxInFlight)
                    return null;

                lock (_messageQueue)
                {
                    if (_messageQueue.Any())
                    {
                        // create new message, send it and track it
                        var msg = new InFlightMessage(_messageQueue.Dequeue().WithPacketId(NextPacketId), 0); // TODO - should this be able to perform an ack?
                        _inFlight.Add(msg);
                        return new List<InFlightMessage> { msg };
                    }
                }

                OutboundMessage obMsg = CompileNextMessage();
                if (obMsg == null)
                    return null;

                uint? ackId = null;
                lock (_lastSentAckLock)
                {
                    bool shouldSend = _readyToAck.HasValue &&
                                      (!_lastSentAck.HasValue ||
                                       !IsPacketCoveredByAck(_lastSentAck.Value, _readyToAck.Value));
                    if (shouldSend)
                        ackId = _readyToAck.Value;
                }

                var newMsg = new InFlightMessage(obMsg.WithPacketId(NextPacketId), ackId);
                _inFlight.Add(newMsg);
                return new List<InFlightMessage> { newMsg };
            }
        }

        protected abstract OutboundMessage CompileNextMessage();

        private void SendMessage(Socket socket, InFlightMessage msg)
        {
            try
            {
                byte[] body = CompileMessage(msg);
                msg.LastSent = DateTime.Now;

                try
                {
                    socket.SendTo(body, SocketFlags.None, Endpoint);
                }
                catch (SocketException e)
                {
                    Log.ErrorFormat("Send failed: {0}", e);
                }
                catch (ObjectDisposedException)
                {
                    Log.ErrorFormat("{0} - Discarding message due to socket being disposed", Endpoint);
                    // Mark as timed out. This will cause it to be cleaned up shortly
                    _lastReceivedTime = DateTime.MinValue;

                    OnDisconnect?.Invoke(this);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Generic error on SendMessage: {0}", ex.StackTrace);
            }
        }

        private byte CompileOpcode(OutboundMessage.OutboundMessageType messageType, bool retry)
        {
            byte res = 0x00;
            switch (messageType)
            {
                case OutboundMessage.OutboundMessageType.Ack:
                    res = (byte)ReceivedPacket.CommandCodeFlags.AckReply;
                    break;
                case OutboundMessage.OutboundMessageType.Ping:
                case OutboundMessage.OutboundMessageType.Command:
                case OutboundMessage.OutboundMessageType.Response:
                    res = (byte)ReceivedPacket.CommandCodeFlags.AckRequest;
                    break;
            }

            if (retry)
                res |= (byte)ReceivedPacket.CommandCodeFlags.IsRetransmit;

            return res;
        }

        private byte[] CompileMessage(InFlightMessage msg)
        {
            byte opcode = CompileOpcode(msg.Message.Type, msg.LastSent != DateTime.MinValue);
            if (msg.AckId.HasValue)
                opcode |= (byte) ReceivedPacket.CommandCodeFlags.AckReply;

            byte len1 = (byte)((ReceivedPacket.HeaderLength + msg.Message.Payload.Length) / 256 | opcode << 3); // opcode 0x08 + length
            byte len2 = (byte)((ReceivedPacket.HeaderLength + msg.Message.Payload.Length) % 256);

            byte[] buffer =
            {
                len1, len2, // Opcode & Length
                (byte) (SessionId >> 8), (byte) SessionId, // session id
                0x00, 0x00, // ACKed Pkt Id
                0x00, 0x00, // Unknown
                0x00, 0x00, // unknown2
                (byte)(msg.Message.PacketId / 256),  (byte)(msg.Message.PacketId % 256), // pkt id
            };

            if (msg.AckId.HasValue || msg.Message.Type == OutboundMessage.OutboundMessageType.Ack)
            {
                var ackId = msg.AckId.GetValueOrDefault(0);
                // set ack id
                buffer[4] = (byte)(ackId / 256);
                buffer[5] = (byte)(ackId % 256);

                // clear pkt id
                if (msg.Message.Type == OutboundMessage.OutboundMessageType.Ack)
                    buffer[10] = buffer[11] = 0x00;
            }

            // If no payload, dont append it
            if (msg.Message.Payload.Length == 0)
                return buffer;

            return buffer.Concat(msg.Message.Payload).ToArray();
        }
    }
}