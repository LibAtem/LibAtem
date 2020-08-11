using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("StRS", CommandDirection.ToClient, 4), NoCommandId]
    public class StreamingStateCommand : SerializableCommandBase
    {
        [Serialize(0), UInt16]
        public uint StreamingStatus { get; set; }
    }
}   
