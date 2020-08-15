using LibAtem.Serialization;

namespace LibAtem.Commands.Recording
{
    [CommandName("RcTM", CommandDirection.ToServer, 4), NoCommandId]
    public class RecordingActiveSetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool IsRecording { get; set; }
    }
}