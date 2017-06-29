namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_SSC")]
    public class SuperSourceConfigCommand : ICommand
    {
        public uint Boxes { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(Boxes);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Boxes = cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}