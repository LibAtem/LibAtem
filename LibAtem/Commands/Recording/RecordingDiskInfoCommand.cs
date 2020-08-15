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

        private static readonly uint DeleteFlag = 1 << 5;
        [Serialize(8), UInt16]
        private uint RawStatus
        {
            get => (uint) Status | (IsDelete ? DeleteFlag : 0);
            set
            {
                IsDelete = (value & DeleteFlag) == DeleteFlag;
                Status = (RecordingDiskStatus) (value & (~DeleteFlag));
            }
        }

        [NoSerialize, Enum16]
        public RecordingDiskStatus Status { get; set; }
        
        [NoSerialize, Bool]
        public bool IsDelete { get; set; }

        [Serialize(10), String(64)]
        public string VolumeName { get; set; }

    }
}