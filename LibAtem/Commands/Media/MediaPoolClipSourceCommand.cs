namespace LibAtem.Commands.Media
{
    [CommandName("MPCS")]
    public class MediaPoolClipSourceCommand : ICommand
    {
        public uint Index { get; set; }
        public bool IsUsed { get; set; }
        public string Name { get; set; }
        public uint FrameCount { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(Index);
            cmd.AddBoolArray(IsUsed);
            cmd.AddString(16, Name);
            cmd.Pad(48); // TODO - is this more name?
            cmd.AddUInt16(FrameCount);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = cmd.GetUInt8();
            IsUsed = cmd.GetBoolArray()[0];
            Name = cmd.GetString(16);
            cmd.Skip(48);
            FrameCount = cmd.GetUInt16();
        }
    }
}