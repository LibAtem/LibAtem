using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using log4net;
using LibAtem.Commands;

namespace LibAtem.Net
{
    public abstract class AtemConnection
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AtemConnection));

        private const int TimeOutMilliseonds = 1000;
        private const uint MaxPacketId = 1 << 16;
        private const uint MaxInFlight = 10;
        private const uint InFlightTimeout = 200;

        public int SessionId { get; }
        public EndPoint Endpoint { get; }

        private readonly object _lastSentAckLock = new object();
        private DateTime _lastReceivedTime;

        private uint _lastPacketId;
        private uint _lastReceivedAck;
        private uint _lastSentAck;

        private readonly Queue<OutboundMessage> _messageQueue;
        private readonly List<InFlightMessage> _inFlight;

        public delegate void DisconnectHandler(object sender);

        public event DisconnectHandler OnDisconnect;

        private class InFlightMessage
        {
            public OutboundMessage Message { get; }
            public uint PktId { get; }
            public DateTime LastSent { get; set; }

            public InFlightMessage(OutboundMessage message, uint pktId)
            {
                Message = message;
                PktId = pktId;
                LastSent = DateTime.MinValue;
            }
        }

        protected AtemConnection(EndPoint endpoint, int sessionId)
        {
            Endpoint = endpoint;
            SessionId = sessionId;
            _lastReceivedTime = DateTime.Now;

            _messageQueue = new Queue<OutboundMessage>();
            _inFlight = new List<InFlightMessage>();
        }

        public bool HasTimedOut => GetTimeSince(_lastReceivedTime) > TimeOutMilliseonds;

        private uint NextPacketId
        {
            get
            {
                uint pktId = ++_lastPacketId;
                if (pktId >= MaxPacketId)
                    return _lastPacketId = 1;

                return pktId;
            }
        }
        
        public void QueuePing()
        {
            QueueMessage(new OutboundMessage(OutboundMessage.OutboundMessageType.Ping, new byte[0]));
        }

        public void QueueMessage(OutboundMessage msg)
        {
            lock (_messageQueue)
            {
                _messageQueue.Enqueue(msg);
            }
        }
        
        public void Receive(Socket socket, ReceivedPacket packet, Action<IReadOnlyList<ICommand>> handler)
        {
            try
            {
                if (HasTimedOut)
                    return;

                lock (_lastSentAckLock)
                {
                    _lastReceivedTime = DateTime.Now;

                    // If we have already acked, then reack
                    if (packet.PacketId > 0 && packet.PacketId < _lastSentAck)
                    {
                        SendAck(socket, _lastSentAck);
                        return;
                    }

                    // If we have skipped something, then discard
                    if (packet.PacketId > _lastSentAck + 1)
                    {
                        Log.DebugFormat("{0} - Discarding message received out of order Got:{1} Expected:{2}", Endpoint, packet.PacketId, _lastSentAck);
                        return;
                    }

                    // Handle it
                    if (packet.PacketId > 0)
                    {
                        _lastSentAck = packet.PacketId;
                        SendAck(socket, packet.PacketId);
                    }

                    Log.DebugFormat("{0} - Command {1}, Length {2}, Session {3:X}, Acked {4}, Packet {5}", Endpoint, 
                        packet.CommandCode, packet.PayloadLength, packet.SessionId, packet.AckedId, packet.PacketId);

                    if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.AckReply))
                    {
                        if (_lastReceivedAck < packet.AckedId)
                            _lastReceivedAck = packet.AckedId;
                    }
                    if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.AckRequest))
                    {
                        Log.DebugFormat("{0} - Parsed {1} commands with length {2}", Endpoint, packet.Commands.Count, packet.PayloadLength);

                        DeserializeCommands(packet, handler);
                    }
                    // Note: Handshake is handled elsewhere
                    // Note: Unknown, Retransmit both need no action
                }
            }
            catch (ArgumentException e)
            {
                //discard as was malformed
            }
        }

        private void DeserializeCommands(ReceivedPacket pkt, Action<IReadOnlyList<ICommand>> handler)
        {
            List<ICommand> commands = new List<ICommand>();

            foreach (ParsedCommand rawCmd in pkt.Commands)
            {
                Log.DebugFormat("{0} - Received command {1} with content {2}", Endpoint, rawCmd.Name, BitConverter.ToString(rawCmd.Body));

                Type commandType = CommandManager.FindForName(rawCmd.Name);
                if (commandType == null)
                {
                    Log.WarnFormat("{0} - Unknown command {1} with content {2}", Endpoint, rawCmd.Name, BitConverter.ToString(rawCmd.Body));
                    continue;
                }

                try
                {
                    ICommand cmd = (ICommand)Activator.CreateInstance(commandType);
                    cmd.Deserialize(rawCmd);

                    if (!rawCmd.HasFinished && !(cmd is SerializableCommandBase))
                        throw new Exception("Some stray bytes were left after deserialize");

                    commands.Add(cmd);
                }
                catch (Exception e)
                {
                    LogManager.GetLogger(commandType).Error(e);
                }
            }

            if (commands.Count == 0)
                return;

            handler(commands);
        }

        private void SendAck(Socket socket, uint packetId)
        {
            // Dont send ack for 0 id, as it is meaningless
            if (packetId == 0)
                return;

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
                SendMessage(socket, msg).Wait();
            return true;
        }

        private int GetTimeSince(DateTime since)
        {
            TimeSpan diff = DateTime.Now - since;
            return diff.Seconds * 1000 + diff.Milliseconds;
        }

        private List<InFlightMessage> ChooseMsg()
        { 
            lock (_inFlight)
            {
                _inFlight.RemoveAll(m => m.PktId <= _lastReceivedAck);
                
                bool shouldResend = _inFlight.Any(m => GetTimeSince(m.LastSent) > InFlightTimeout);
                // If any were resent, then dont send anything new
                if (shouldResend)
                {
                    List<InFlightMessage> toResend = _inFlight.OrderBy(m => m.PktId).ToList();
                    Log.WarnFormat("{0} - Resending {1} packets from #{2}", Endpoint, toResend.Count, toResend[0].PktId);
                    return toResend;
                }

                if (_inFlight.Count >= MaxInFlight)
                    return null;

                lock (_messageQueue)
                {
                    if (_messageQueue.Any())
                    {
                        // create new message, send it and track it
                        var msg = new InFlightMessage(_messageQueue.Dequeue(), NextPacketId);
                        _inFlight.Add(msg);
                        return new List<InFlightMessage> { msg };
                    }
                }

                OutboundMessage obMsg = CompileNextMessage();
                if (obMsg == null)
                    return null;

                var newMsg = new InFlightMessage(obMsg, NextPacketId);
                _inFlight.Add(newMsg);
                return new List<InFlightMessage> {newMsg};
            }
        }

        protected virtual OutboundMessage CompileNextMessage()
        {
            return null;
        }
        
        private async Task SendMessage(Socket socket, InFlightMessage msg)
        {
            byte[] body = CompileMessage(msg);
            msg.LastSent = DateTime.Now;

            try
            {
                await socket.SendToAsync(new ArraySegment<byte>(body, 0, body.Length), SocketFlags.None, Endpoint);
            }
            catch (ObjectDisposedException)
            {
                Log.ErrorFormat("{0} - Discarding message due to socket being disposed", Endpoint);
                // Mark as timed out. This will cause it to be cleaned up shortly
                _lastReceivedTime = DateTime.MinValue;

                OnDisconnect?.Invoke(this);
            }
        }
        
        private byte CompileOpcode(OutboundMessage.OutboundMessageType messageType, bool retry)
        {
            byte res = 0x00;
            switch (messageType)
            {
                case OutboundMessage.OutboundMessageType.Ack:
                    res = (byte) ReceivedPacket.CommandCodeFlags.AckReply;
                    break;
                case OutboundMessage.OutboundMessageType.Ping:
                case OutboundMessage.OutboundMessageType.Command:
                case OutboundMessage.OutboundMessageType.Response:
                    res = (byte) ReceivedPacket.CommandCodeFlags.AckRequest;
                    break;
            }

            if (retry)
                res |= (byte) ReceivedPacket.CommandCodeFlags.Retransmission;

            return res;
        }
        
        private byte[] CompileMessage(InFlightMessage msg)
        {
            byte opcode = CompileOpcode(msg.Message.Type, msg.LastSent != DateTime.MinValue);
            byte len1 = (byte)((ReceivedPacket.HeaderLength + msg.Message.Payload.Length) / 256 | opcode << 3); // opcode 0x08 + length
            byte len2 = (byte)((ReceivedPacket.HeaderLength + msg.Message.Payload.Length) % 256);

            byte[] buffer =
            {
                len1, len2, // Opcode & Length
                (byte)(SessionId / 256),  (byte)(SessionId % 256), // session id
                0x00, 0x00, // ACKed Pkt Id
                0x00, 0x00, // Unknown
                0x00, 0x00, // unknown2
                (byte)(msg.PktId / 256),  (byte)(msg.PktId % 256), // pkt id
            };

            if (msg.Message.Type == OutboundMessage.OutboundMessageType.Ack)
            {
                // set ack id
                buffer[4] = buffer[10];
                buffer[5] = buffer[11];

                // clear pkt id
                buffer[10] = buffer[11] = 0x00;
            }

            // If no payload, dont append it
            if (msg.Message.Payload.Length == 0)
                return buffer;

            return buffer.Concat(msg.Message.Payload).ToArray();
        }
    }
}