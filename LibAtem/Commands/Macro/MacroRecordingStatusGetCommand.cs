namespace LibAtem.Commands.Macro
{
    [CommandName("MRcS")]
    public class MacroRecordingStatusGetCommand : ICommand
    {
        public bool IsRecording { get; set; }
        public uint Index { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddBoolArray(IsRecording);
            cmd.AddByte(0x50); // ??
            cmd.AddUInt16(Index);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            IsRecording = cmd.GetBoolArray()[0];
            cmd.Skip();
            Index = cmd.GetUInt16();
        }
    }
}