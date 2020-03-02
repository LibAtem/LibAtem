using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXCC", CommandDirection.ToClient)]
    public class HyperDeckRXCCCommand : ICommand
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint Id { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(Id);
            cmd.AddByte(0x00, 0x0A);
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Id = cmd.GetUInt16();
            cmd.Skip(4);
        }
    }
}