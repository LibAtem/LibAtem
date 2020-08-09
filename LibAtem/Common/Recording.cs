namespace LibAtem.Common
{
    public enum RecordingError
    {
        None = 0,
        NoMedia = 1,
        MediaFull = 2,
        MediaError = 3,
        MediaUnformatted = 4,
        DroppingFrames = 5,
        Unknown = 6,
    }

    public enum RecordingState
    {
        Idle = 0,
        Recording = 1,
        Stopping = 2,
    }

    public enum RecordingDiskStatus
    {
        Idle = 0,
        Unformatted = 1,
        Active = 2,
        Recording = 3,
    }
}
