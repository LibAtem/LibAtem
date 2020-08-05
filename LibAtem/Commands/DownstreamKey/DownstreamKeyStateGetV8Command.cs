using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DskS", CommandDirection.ToClient, ProtocolVersion.V8_0_1, 8)]
    public class DownstreamKeyStateGetV8Command : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serialize(1), Bool]
        public bool OnAir { get; set; }
        [Serialize(2), Bool]
        public bool InTransition { get; set; }
        [Serialize(3), Bool]
        public bool IsAuto { get; set; }
        [Serialize(4), Bool]
        public bool IsTowardsOnAir { get; set; }
        [Serialize(5), UInt8Range(0, 250)]
        public uint RemainingFrames { get; set; }
    }
}