namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_mpl")]
    public class MediaPoolConfigCommand : ICommand
    {
        public uint StillCount { get; set; }
        public uint ClipCount { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(StillCount);
            cmd.AddUInt8(ClipCount);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            StillCount = cmd.GetUInt8();
            ClipCount = cmd.GetUInt8();
            cmd.Skip(2);
        }
    }
}