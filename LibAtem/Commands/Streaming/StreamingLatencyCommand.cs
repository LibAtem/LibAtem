using System.Collections.Generic;
using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("SLow", CommandDirection.Both, ProtocolVersion.V8_1_1, 4), NoCommandId]
    public class StreamingLatencyCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool LowLatency { get; set; }
    }
}