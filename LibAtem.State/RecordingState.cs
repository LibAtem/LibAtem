using System;
using System.Collections.Generic;

namespace LibAtem.State
{
    [Serializable]
    public class RecordingState
    {

        public IReadOnlyList<RecordingDiskState> Disks { get; set; } = new List<RecordingDiskState>();
    }
    [Serializable]
    public class RecordingDiskState
    {
        public uint DiskId { get; set; }
        public string VolumeName { get; set; }
        public uint RecordingTimeAvailable { get; set; }

        // public RecordingDiskStatus Status { get; set; }
    }
}