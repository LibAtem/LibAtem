using LibAtem.Serialization;

namespace LibAtem.Commands.Macro
{
    [CommandName("MRCP", 4), NoCommandId]
    public class MacroRunStatusSetCommand : SerializableCommandBase
    {
        public enum MaskFlags
        {
            Looping = 0,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serialize(1), Bool]
        public bool Looping { get; set; }
    }
}