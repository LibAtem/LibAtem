using System;

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
        Stopping = 0x24, // 1 << 5 + 1 << 2,
    }

    public static class StreamingStatusExt
    {
        private const uint Connecting = 1 << 1;
        private const uint Connecting2 = 1 << 3;
        private const uint Streaming = 1 << 2;
        private const uint Stopping = 1 << 5;

        private const uint ErrorUnknown = 1 << 15;
        private const uint ErrorInvalidState = 1 << 4;

        public static Tuple<StreamingStatus, StreamingError> ParseStreamingStatus(this uint raw)
        {
            var status = StreamingStatus.Idle;
            var error = StreamingError.None;

            if ((raw & Connecting) > 0 || (raw & Connecting2) > 0)
            {
                status = StreamingStatus.Connecting;
            }
            if ((raw & Streaming) > 0)
            {
                status = StreamingStatus.Streaming;
            }
            if ((raw & Stopping) > 0)
            {
                status = StreamingStatus.Stopping;
            }

            if ((raw & ErrorUnknown) > 0)
            {
                error = StreamingError.Unknown;
            }
            if ((raw & ErrorInvalidState) > 0)
            {
                error = StreamingError.InvalidState;
            }

            return Tuple.Create(status, error);
        }

        public static uint EncodeStreamingStatus(StreamingStatus status, StreamingError error)
        {
            uint res = 0;

            switch (status)
            {
                case StreamingStatus.Idle:
                    break;
                case StreamingStatus.Connecting:
                    res |= Connecting;
                    break;
                case StreamingStatus.Streaming:
                    res |= Streaming;
                    break;
                case StreamingStatus.Stopping:
                    res |= Stopping;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }

            switch (error)
            {
                case StreamingError.None:
                    break;
                case StreamingError.InvalidState:
                    res |= ErrorInvalidState;
                    break;
                case StreamingError.Unknown:
                    res |= ErrorUnknown;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(error), error, null);
            }

            return res;
        }
    }
}
