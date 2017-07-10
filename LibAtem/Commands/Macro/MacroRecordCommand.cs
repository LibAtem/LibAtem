namespace LibAtem.Commands.Macro
{
    [CommandName("MSRc")]
    public class MacroRecordCommand : ICommand
    {
        public uint Index { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16(Index);
            cmd.AddUInt16(Name.Length);
            cmd.AddUInt16(Description.Length);
            cmd.AddString(Name);
            cmd.AddString(Description);
            cmd.PadToNearestPowerOfTwo();
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = cmd.GetUInt16();
            uint nameLenth = cmd.GetUInt16();
            uint descriptionLength = cmd.GetUInt16();
            Name = cmd.GetString(nameLenth);
            Description = cmd.GetString(descriptionLength);
            cmd.SkipToNearestPowerOfTwo();
        }
    }
}