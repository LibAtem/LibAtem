using System.Collections.Generic;
using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("SLow", CommandDirection.ToClient, ProtocolVersion.V8_1_1, 4), NoCommandId]
    public class StreamingLatencyGetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool LowLatency { get; set; }
    }
}