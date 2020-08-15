using System;

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

    public enum RecordingStatus
    {
        Idle = 0,
        Recording = 1,
        Stopping = 2,
    }

    public enum RecordingDiskStatus
    {
        Idle = 1 << 0,
        Unformatted = 1 << 1,
        Active = 1 << 2,
        Recording = 1 << 3,

        Removed = 1 << 5
    }

    public static class RecordingStatusExt
    {
        private const uint Recording = 1 << 0;
        private const uint Stopping = 1 << 7;

        private const uint HasMedia = 1 << 1;
        private const uint ErrorUnknown = 1 << 15;
        private const uint ErrorFull = 1 << 2;
        private const uint ErrorError = 1 << 3;
        private const uint ErrorUnformatted = 1 << 4;
        private const uint ErrorDroppingFrames = 1 << 5;

        public static Tuple<RecordingStatus, RecordingError> ParseRecordingStatus(this uint raw)
        {
            var status = RecordingStatus.Idle;
            var error = RecordingError.NoMedia;

            if ((raw & Recording) > 0)
            {
                status = RecordingStatus.Recording;
            }
            if ((raw & Stopping) > 0)
            {
                status = RecordingStatus.Stopping;
            }

            if ((raw & HasMedia) > 0)
            {
                error = RecordingError.None;

                if ((raw & ErrorUnknown) > 0)
                {
                    error = RecordingError.Unknown;
                }
                if ((raw & ErrorFull) > 0)
                {
                    error = RecordingError.MediaFull;
                }
                if ((raw & ErrorError) > 0)
                {
                    error = RecordingError.MediaError;
                }
                if ((raw & ErrorUnformatted) > 0)
                {
                    error = RecordingError.MediaUnformatted;
                }
                if ((raw & ErrorDroppingFrames) > 0)
                {
                    error = RecordingError.DroppingFrames;
                }
            }

            return Tuple.Create(status, error);
        }

        public static uint EncodeRecordingStatus(RecordingStatus status, RecordingError error)
        {
            uint res = 0;

            switch (status)
            {
                case RecordingStatus.Idle:
                    break;
                case RecordingStatus.Recording:
                    res |= Recording;
                    break;
                case RecordingStatus.Stopping:
                    res |= Stopping;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }

            switch (error)
            {
                case RecordingError.NoMedia:
                    break;
                case RecordingError.None:
                    res |= HasMedia;
                    break;
                case RecordingError.Unknown:
                    res |= ErrorUnknown | HasMedia;
                    break;
                case RecordingError.MediaFull:
                    res |= ErrorFull | HasMedia;
                    break;
                case RecordingError.MediaError:
                    res |= ErrorError | HasMedia;
                    break;
                case RecordingError.MediaUnformatted:
                    res |= ErrorUnformatted | HasMedia;
                    break;
                case RecordingError.DroppingFrames:
                    res |= ErrorDroppingFrames | HasMedia;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(error), error, null);
            }

            return res;
        }
    }
}
