namespace LibAtem.Commands.Macro
{
    [CommandName("MAct", 4)]
    public class MacroActionCommand : ICommand
    {
        public enum MacroAction
        {
            Run = 0,
            Stop = 1,
            StopRecord = 2,
            InsertUserWait = 3,
            Continue = 4,
            Delete = 5,
        }

        [CommandId]
        public uint Index { get; set; }
        public MacroAction Action { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            switch (Action)
            {
                case MacroAction.Run:
                case MacroAction.Delete:
                    cmd.AddUInt16(Index);
                    break;
                default:
                    cmd.AddUInt16(0xFFFF);
                    break;
            }

            cmd.AddUInt8((int) Action);
            cmd.Pad();
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = cmd.GetUInt16();
            Action = (MacroAction) cmd.GetUInt8();
            cmd.Skip();
        }
    }
}