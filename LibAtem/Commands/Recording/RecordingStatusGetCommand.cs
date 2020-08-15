using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.Serialization;
using LibAtem.Util;

namespace LibAtem.Commands.Recording
{
    [CommandName("RTMS", CommandDirection.ToClient, 8), NoCommandId]
    public class RecordingStatusGetCommand : SerializableCommandBase
    {

        [Serialize(0), UInt16]
        private uint RawRecordingStatus
        {
            get
            {
                uint res = (uint)Error | (uint)Status;
                if (Error != RecordingError.NoMedia && Error != RecordingError.None)
                    res |= (uint) RecordingError.None;

                return res;
            }
            set
            {
                List<RecordingError> errorFlags = ((RecordingError)value).FindFlagComponents();

                RecordingError defVal = errorFlags.Contains(RecordingError.None)
                    ? RecordingError.None
                    : RecordingError.NoMedia;
                errorFlags.Remove(defVal);

                Status = ((RecordingStatus)value).FindFlagComponents().FirstOrDefault(RecordingStatus.Idle);
                Error = errorFlags.FirstOrDefault(defVal);
            }

        }

        [NoSerialize]
        public RecordingStatus Status { get; set; }
        [NoSerialize]
        public RecordingError Error { get; set; }

        [Serialize(4), UInt32]
        public uint TotalRecordingTimeAvailable { get; set; }
    }
}