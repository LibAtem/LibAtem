using System.Collections.Generic;
using System.IO;
using LibAtem.Commands;

namespace LibAtem.Net
{
    public class OutboundMessage
    {
        public enum OutboundMessageType
        {
            Ack,
            Command,
            Response,
            Ping,
        }

        public OutboundMessageType Type { get; }
        public byte[] Payload { get; }
        public uint PacketId { get; }

        public OutboundMessage(OutboundMessageType type, byte[] payload) : this(type, payload, 0)
        {
        }

        private OutboundMessage(OutboundMessageType type, byte[] payload, uint pktId)
        {
            Type = type;
            Payload = payload;
            PacketId = pktId;
        }

        public OutboundMessage WithPacketId(uint pktId)
        {
            return new OutboundMessage(Type, Payload, pktId);
        }
    }

    public class OutboundMessageBuilder
    {
        private const int maxLength = AtemConstants.MaxPacketLength - ReceivedPacket.HeaderLength;

        private readonly MemoryStream current;
        private readonly BinaryWriter writer;
        private int currentLength;

        public OutboundMessageBuilder()
        {
            current = new MemoryStream();
            writer = new BinaryWriter(current);

            currentLength = 0;
        }

        public bool TryAddCommand(ICommand cmd)
        {
            return TryAddCommands(new List<ICommand> {cmd});
        }

        public bool TryAddCommands(IReadOnlyList<ICommand> commands)
        {
            int newLength = currentLength;
            List<byte[]> datasets = new List<byte[]>(commands.Count);
            foreach (ICommand res in commands)
            {
                byte[] data = res.ToByteArray();
                if (newLength + data.Length > maxLength && currentLength != 0)
                    return false;

                datasets.Add(data);
                newLength += data.Length;
            }

            currentLength = newLength;
            datasets.ForEach(d => writer.Write(d));
            return true;
        }

        public OutboundMessage Create()
        {
            return new OutboundMessage(OutboundMessage.OutboundMessageType.Command, current.ToArray());
        }
    }
}