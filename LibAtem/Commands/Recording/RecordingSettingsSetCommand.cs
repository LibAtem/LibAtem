using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Recording
{
    [CommandName("CRMS", CommandDirection.ToServer, 144), NoCommandId]
    public class RecordingSettingsSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Filename = 1 << 0,
            WorkingSet1DiskId = 1 << 1,
            WorkingSet2DiskId = 1 << 2,
            RecordInAllCameras = 1 << 3,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [Serialize(1), String(128)]
        public string Filename { get; set; }

        [Serialize(132), UInt32]
        public uint WorkingSet1DiskId { get; set; }
        [Serialize(136), UInt32]
        public uint WorkingSet2DiskId { get; set; }

        [Serialize(140), Bool]
        public bool RecordInAllCameras { get; set; }
    }
}