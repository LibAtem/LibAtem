using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.Serialization;
using LibAtem.Util;

namespace LibAtem.Commands.Streaming
{
    [CommandName("StRS", CommandDirection.ToClient, ProtocolVersion.V8_1_1,4), NoCommandId]
    public class StreamingStatusGetCommand : SerializableCommandBase
    {
        [Serialize(0), UInt16]
        private uint RawStreamingStatus
        {
            get
            {
                uint res = (uint) Error | (uint) Status;
                if (Status == StreamingStatus.Stopping)
                    res |= (uint) StreamingStatus.Streaming;

                return res;
            }
            set
            {
                List<StreamingStatus> statusFlags = ((StreamingStatus) value).FindFlagComponents();
                if (statusFlags.Contains(StreamingStatus.Stopping))
                    Status = StreamingStatus.Stopping;
                else 
                    Status = statusFlags.FirstOrDefault(StreamingStatus.Idle);

                Error = ((StreamingError) value).FindFlagComponents().FirstOrDefault(StreamingError.None);
            }
        }

        [NoSerialize, Enum8]
        public StreamingStatus Status { get; set; }
        [NoSerialize, Enum8]
        public StreamingError Error { get; set; }
    }
}   
