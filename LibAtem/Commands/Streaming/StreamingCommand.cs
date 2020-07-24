using System.Collections.Generic;
using System.Text;
using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("StrR", CommandDirection.ToServer, 4), NoCommandId]
    public class StreamingActiveSetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool IsStreaming { get; set; }
    }


    public enum StreamingStatus
    {
        Idle = 1 << 0,
        Connecting = 1 << 1,
        Streaming = 1 << 2,
        Stopping = 1 << 3,
    }

    [CommandName("StRS", CommandDirection.ToClient, 4), NoCommandId]
    public class StreamingStateCommand : SerializableCommandBase
    {
        [Serialize(0), Enum16]
        public StreamingStatus StreamingStatus { get; set; }
    }

    [CommandName("SRSS", CommandDirection.ToClient, 8), NoCommandId]
    public class SRSSCommand : SerializableCommandBase
    {
    }
}
