using LibAtem.Serialization;

namespace LibAtem.Commands.Recording
{
    [CommandName("RcTM", CommandDirection.ToServer, ProtocolVersion.V8_1_1, 4), NoCommandId]
    public class RecordingStatusSetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool IsRecording { get; set; }
    }
}