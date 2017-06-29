namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXCP")]
    public class HyperDeckRXCPCommand : ICommand
    {
        public uint Id { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16(Id);
            cmd.AddByte(0x01, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Id = cmd.GetUInt16();
            cmd.Skip(20);
        }
    }
}