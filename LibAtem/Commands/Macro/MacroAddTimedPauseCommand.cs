using LibAtem.Serialization;

namespace LibAtem.Commands.Macro
{
    [CommandName("MSlp", 4)]
    public class MacroAddTimedPauseCommand : SerializableCommandBase
    {
        [Serialize(2), UInt16Range(0, 2500)]
        public uint Frames { get; set; }
    }
}