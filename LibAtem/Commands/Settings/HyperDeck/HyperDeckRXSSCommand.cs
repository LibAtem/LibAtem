using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXSS", CommandDirection.ToClient)]
    public class HyperDeckRXSSCommand : ICommand
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint Id { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(Id);
            cmd.AddByte(0x52, 0x65, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x10, 0xA4, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x62, 0x61);
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Id = cmd.GetUInt16();
            cmd.Skip(32);
        }
    }
}