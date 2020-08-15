using System;

namespace LibAtem.Common
{
    public enum RecordingError
    {
        None = 1 << 1,
        NoMedia = 0,
        MediaFull = 1 << 2,
        MediaError = 1 << 3,
        MediaUnformatted = 1 << 4,
        DroppingFrames = 1 << 5,
        Unknown = 1 << 15,
    }

    public enum RecordingStatus
    {
        Idle = 0,
        Recording = 1 << 0,
        Stopping = 1 << 7,
    }

    public enum RecordingDiskStatus
    {
        Idle = 1 << 0,
        Unformatted = 1 << 1,
        Active = 1 << 2,
        Recording = 1 << 3,
    }
}
