using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DskS", CommandDirection.ToClient, 8)]
    public class DownstreamKeyStateGetCommand : SerializableCommandBase
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
        [Serialize(4), UInt8Range(0, 250)]
        public uint RemainingFrames { get; set; }
    }
}