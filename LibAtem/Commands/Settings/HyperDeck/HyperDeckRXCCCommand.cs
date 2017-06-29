namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXCC")]
    public class HyperDeckRXCCCommand : ICommand
    {
        public uint Id { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16((uint) Id);
            cmd.AddByte(0x00, 0x0A);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Id = cmd.GetUInt16();
            cmd.Skip(4);
        }
    }
}