using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Recording
{
    [CommandName("RTMD", CommandDirection.ToClient, ProtocolVersion.V8_1_1, 76)]
    public class RecordingDiskInfoCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt32]
        public uint DiskId { get; set; }

        [Serialize(4), UInt32]
        public uint RecordingTimeAvailable { get; set; }

        [Serialize(8), Enum16]
        public RecordingDiskStatus Status { get; set; }

        [Serialize(10), String(64)]
        public string VolumeName { get; set; }

    }
}