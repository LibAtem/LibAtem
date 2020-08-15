using System.Collections.Generic;
using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("STAB", CommandDirection.Both, ProtocolVersion.V8_1_1, 8), NoCommandId]
    public class StreamingAudioBitratesCommand : SerializableCommandBase
    {
        [Serialize(0), UInt32List(2)]
        public List<uint> Bitrates { get; set; }
    }
}