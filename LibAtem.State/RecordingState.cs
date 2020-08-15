using System;
using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class RecordingState
    {
        public bool CanISORecordAllInputs { get; set; }
        public bool ISORecordAllInputs { get; set; }

        public PropertiesState Properties { get; } = new PropertiesState();
        public StatusState Status { get; } = new StatusState();

        public Dictionary<uint, RecordingDiskState> Disks { get; set; } = new Dictionary<uint, RecordingDiskState>();

        [Serializable]
        public class StatusState
        {
            public uint TotalRecordingTimeAvailable { get; set; }

            public Timecode Duration { get; set; }

            public RecordingStatus State { get; set; }
            public RecordingError Error { get; set; }
        }


        [Serializable]
        public class PropertiesState
        {
            public string Filename { get; set; }

            public uint WorkingSet1DiskId { get; set; }
            public uint WorkingSet2DiskId { get; set; }

            public bool RecordInAllCameras { get; set; }
        }

        [Serializable]
        public class RecordingDiskState
        {
            public uint DiskId { get; set; }
            public string VolumeName { get; set; }
            public uint RecordingTimeAvailable { get; set; }

            public RecordingDiskStatus Status { get; set; }
        }
    }
}