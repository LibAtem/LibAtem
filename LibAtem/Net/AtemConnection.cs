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

        private readonly EndPoint _endpoint;
        private readonly int _sessionId;

        private readonly object _lastSentAckLock = new object();
        private DateTime _lastReceivedAckTime;

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

        public AtemConnection(EndPoint endpoint, int sessionId)
        {
            _endpoint = endpoint;
            _sessionId = sessionId;
            _lastReceivedAckTime = DateTime.Now;

            _messageQueue = new Queue<OutboundMessage>();
            _inFlight = new List<InFlightMessage>();
        }

        public int SessionId => _sessionId;
        public EndPoint Endpoint => _endpoint;

        public bool HasTimedOut
        {
            get
            {
                TimeSpan diff = (DateTime.Now - _lastReceivedAckTime);
                int time = diff.Seconds * 1000 + diff.Milliseconds;
                
                return time > TimeOutMilliseonds;
            }
        }

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
        
        public void SendPing(ref Socket socket)
        {
            SendMessage(socket, new InFlightMessage(new OutboundMessage(OutboundMessage.OutboundMessageType.Ping, new byte[0]), NextPacketId));
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
                lock (_lastSentAckLock)
                {
                    // If we have already acked, then reack
                    if (packet.PacketId > 0 && packet.PacketId < _lastSentAck)
                    {
                        SendAck(socket, _lastSentAck);
                        return;
                    }

                    // If we have skipped something, then discard
                    if (packet.PacketId > _lastSentAck + 1)
                        return;

                    // Handle it
                    if (packet.PacketId > 0)
                    {
                        _lastSentAck = packet.PacketId;
                        SendAck(socket, packet.PacketId);
                    }

                    Log.DebugFormat("Command {0}, Length {1}, Session {2:X}, Acked {3:X}, Packet {4:X}", packet.CommandCode,
                        packet.PayloadLength, packet.SessionId, packet.AckedId, packet.PacketId);

                    if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.AckReply))
                    {
                        _lastReceivedAckTime = DateTime.Now;
                        if (_lastReceivedAck < packet.AckedId)
                            _lastReceivedAck = packet.AckedId;
                    }
                    if (packet.CommandCode.HasFlag(ReceivedPacket.CommandCodeFlags.AckRequest))
                    {
                        Log.DebugFormat("Parsed {0} commands with length {1}", packet.Commands.Count, packet.PayloadLength);

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
                Log.DebugFormat("Received command {0} with content {1}", rawCmd.Name, BitConverter.ToString(rawCmd.Body));

                Type commandType = CommandManager.FindForName(rawCmd.Name);
                if (commandType == null)
                {
                    Log.WarnFormat("Unknown command {0} with content {1}", rawCmd.Name, BitConverter.ToString(rawCmd.Body));
                    continue;
                }

                ICommand cmd = (ICommand)Activator.CreateInstance(commandType);
                try
                {
                    cmd.Deserialize(rawCmd);

                    if (!rawCmd.HasFinished && !(cmd is SerializableCommandBase))
                        throw new Exception("Some stray bytes were left after deserialize");
                }
                catch (Exception e)
                {
                    LogManager.GetLogger(commandType).Error(e);
                    continue;
                }

                commands.Add(cmd);
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

        public async Task<bool> TrySendAsync(Socket socket)
        {
            if (HasTimedOut)
                return false;

            bool resend;
            var msg = ChooseMsg(out resend);
            if (msg == null)
                return false;

            await SendMessage(socket, msg);
            return true;
        }

        private InFlightMessage ChooseMsg(out bool resend)
        { 
            resend = false;
            lock (_inFlight)
            {
                _inFlight.RemoveAll(m => m.PktId >= _lastReceivedAck);

                InFlightMessage toResend = _inFlight.FirstOrDefault(m => (m.LastSent - DateTime.Now).Milliseconds > InFlightTimeout);
                // If any were resent, then dont send anything new
                if (toResend != null)
                {
                    resend = true;
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
                        return msg;
                    }
                }

                OutboundMessage obMsg = CompileNextMessage();
                if (obMsg == null)
                    return null;

                var newMsg = new InFlightMessage(obMsg, NextPacketId);
                _inFlight.Add(newMsg);
                return newMsg;
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
                await socket.SendToAsync(new ArraySegment<byte>(body, 0, body.Length), SocketFlags.None, _endpoint);
            }
            catch (ObjectDisposedException)
            {
                Log.Error("Discarding message due to socket being disposed");
                // Mark as timed out. This will cause it to be cleaned up shortly
                _lastReceivedAckTime = DateTime.MinValue;

                if (OnDisconnect != null)
                    OnDisconnect(this);
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
                (byte)(_sessionId / 256),  (byte)(_sessionId % 256), // session id
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