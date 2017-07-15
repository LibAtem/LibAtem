using LibAtem.Serialization;

namespace LibAtem.Commands.Macro
{
    [CommandName("MRcS", 4), NoCommandId]
    public class MacroRecordingStatusGetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool IsRecording { get; set; }
        [Serialize(2), UInt16]
        public uint Index { get; set; }
    }
}