using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXCP", CommandDirection.ToClient)]
    public class HyperDeckRXCPCommand : ICommand
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint Id { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(Id);
            cmd.AddByte(0x01, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00);
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Id = cmd.GetUInt16();
            cmd.Skip(20);
        }
    }
}