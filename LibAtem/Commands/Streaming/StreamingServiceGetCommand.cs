using System.Collections.Generic;
using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("SRSU", CommandDirection.ToClient, 1096)]
    public class StreamingServiceGetCommand : SerializableCommandBase
    {
        [Serialize(0), String(64)]
        public string ServiceName { get; set; }
        [Serialize(64), String(512)]
        public string Url { get; set; }
        [Serialize(576), String(512)]
        public string Key { get; set; }

        [Serialize(1088), UInt32List(2)]
        public List<uint> Bitrates { get; set; }
    }
}