namespace LibAtem.Commands.Macro
{
    [CommandName("MRPr")]
    public class MacroRunStatusGetCommand : ICommand
    {
        public bool IsRunning { get; set; }
        public bool IsWaiting { get; set; }
        public bool Loop { get; set; }
        public uint Index { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddBoolArray(IsRunning, IsWaiting);
            cmd.AddBoolArray(Loop);
            cmd.AddUInt16((uint) Index);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            bool[]  arr = cmd.GetBoolArray();
            IsRunning = arr[0];
            IsWaiting = arr[1];
            Loop = cmd.GetBoolArray()[0];
            Index = cmd.GetUInt16();
        }
    }
}