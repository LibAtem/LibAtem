namespace LibAtem.Commands.Media
{
    [CommandName("MPAS")]
    public class MediaPoolAudioSourceCommand : ICommand
    {
        public uint Index { get; set; }
        public bool IsUsed { get; set; }
        public string Name { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(Index);
            cmd.AddBoolArray(IsUsed);
            cmd.Pad(16);
            cmd.AddString(16, Name);
            cmd.Pad(50); // TODO - is this more name?
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = cmd.GetUInt8();
            IsUsed = cmd.GetBoolArray()[0];
            cmd.Skip(16);
            Name = cmd.GetString(16);
            cmd.Skip(50);
        }
    }
}