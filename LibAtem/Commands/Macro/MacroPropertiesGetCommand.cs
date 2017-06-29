namespace LibAtem.Commands.Macro
{
    [CommandName("MPrp")]
    public class MacroPropertiesGetCommand : ICommand
    {
        public uint Index { get; set; }
        public bool IsUsed { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16(Index);
            cmd.AddBoolArray(IsUsed);
            cmd.Pad(); // ??
            cmd.AddUInt16(Name.Length);
            cmd.AddUInt16(Description.Length);
            cmd.AddString(Name);
            cmd.AddString(Description);
            cmd.PadToNearestPowerOfTwo();
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = cmd.GetUInt16();
            IsUsed = cmd.GetBoolArray()[0];
            Name = cmd.GetString(cmd.GetUInt16());
            Description = cmd.GetString(cmd.GetUInt16());
            cmd.SkipToNearestPowerOfTwo();
        }
    }
}