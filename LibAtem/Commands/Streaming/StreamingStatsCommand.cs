using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("SRSS", CommandDirection.ToClient, 8), NoCommandId]
    public class StreamingStatsCommand : SerializableCommandBase
    {
        [Serialize(0), UInt32]
        public uint EncodingBitrate { get; set; }
        
        [Serialize(4), UInt16Range(0, 100)]
        public uint CacheUsed { get; set; }
    }
}