using LibAtem.Serialization;

namespace LibAtem.Commands.Macro
{
    [CommandName("MRcS", 4)]
    public class MacroRecordingStatusGetCommand : SerializableCommandBase
    {
        [Serializable(0), Bool]
        public bool IsRecording { get; set; }
        [Serializable(2), UInt16]
        public uint Index { get; set; }
    }
}