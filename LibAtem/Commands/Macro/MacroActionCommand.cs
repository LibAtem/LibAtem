using LibAtem.Serialization;

namespace LibAtem.Commands.Macro
{
    [CommandName("MAct", 4)]
    public class MacroActionCommand : SerializableCommandBase
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
        [Serialize(0), UInt16]
        public uint Index { get; set; }
        [Serialize(2), Enum8]
        public MacroAction Action { get; set; }

        public override void Serialize(ByteArrayBuilder cmd)
        {
            switch (Action)
            {
                case MacroAction.Run:
                case MacroAction.Delete:
                    cmd.AddUInt16(Index);
                    break;
                default:
                    cmd.AddUInt16(0xFFFF);
                    Index = 0xFFFF;
                    break;
            }

            cmd.AddUInt8((int)Action);
            cmd.Pad();
        }
    }
}