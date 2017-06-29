namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_MAC")]
    public class MacroPoolConfigCommand : ICommand
    {
        public uint MacroCount { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(MacroCount);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MacroCount = cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}