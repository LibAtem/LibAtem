using LibAtem.Serialization;

namespace LibAtem.Commands.Recording
{
    [CommandName("RTMS", CommandDirection.ToClient, 8), NoCommandId]
    public class RecordingStatusCommand : SerializableCommandBase
    {

        [Serialize(0), UInt16]
        public uint RecordingStatus { get; set; } // TODO - this is not correct

        [Serialize(4), UInt32]
        public uint TotalRecordingTimeAvailable { get; set; }
    }
}