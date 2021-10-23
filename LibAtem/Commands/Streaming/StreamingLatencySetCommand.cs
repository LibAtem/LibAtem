using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("SLow", CommandDirection.ToServer, ProtocolVersion.V8_1_1, 4), NoCommandId]
    public class StreamingLatencySetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool LowLatency { get; set; }
    }
}