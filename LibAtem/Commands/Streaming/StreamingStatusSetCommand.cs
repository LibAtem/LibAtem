using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("StrR", CommandDirection.ToServer, 4), NoCommandId]
    public class StreamingStatusSetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool IsStreaming { get; set; }
    }
}