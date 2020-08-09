using System.Collections.Generic;
using System.Text;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("StrR", CommandDirection.ToServer, 4), NoCommandId]
    public class StreamingActiveSetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool IsStreaming { get; set; }
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
