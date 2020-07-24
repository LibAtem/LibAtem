using System;
using System.Collections.Generic;
using LibAtem.Serialization;

namespace LibAtem.Commands.Streaming
{
    [CommandName("CRSS", CommandDirection.ToServer, 1100), NoCommandId]
    public class StreamingServiceSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            ServiceName = 1 << 0,
            Url = 1 << 1,
            Key = 1 << 2,
            Bitrates = 1 << 3,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [Serialize(1), String(64)]
        public string ServiceName { get; set; }
        [Serialize(65), String(512)]
        public string Url { get; set; }
        [Serialize(577), String(512)]
        public string Key { get; set; }

        [Serialize(1092), UInt32List(2)]
        public List<uint> Bitrates { get; set; }
    }
}