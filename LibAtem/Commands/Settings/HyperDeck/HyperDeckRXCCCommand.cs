namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXCC")]
    public class HyperDeckRXCCCommand : ICommand
    {
        [CommandId]
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