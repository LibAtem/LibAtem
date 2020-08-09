namespace LibAtem.Common
{
    public enum StreamingError
    {
        None = 0,
        InvalidState = 1,
        Unknown = 2
    }

    public enum StreamingStatus
    {
        Idle = 1 << 0,
        Connecting = 1 << 1,
        Streaming = 1 << 2,
        Stopping = 1 << 3,
    }
}
