using LibAtem.Serialization;

namespace LibAtem.Commands.Macro
{
    [CommandName("MRCP", CommandDirection.ToServer, 4), NoCommandId]
    public class MacroRunStatusSetCommand : SerializableCommandBase
    {
        public enum MaskFlags
        {
            Loop = 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serialize(1), Bool]
        public bool Loop { get; set; }
    }
}