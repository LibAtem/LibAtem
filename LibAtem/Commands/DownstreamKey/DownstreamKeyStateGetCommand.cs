using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DskS", 8)]
    public class DownstreamKeyStateGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serializable(1), Bool]
        public bool OnAir { get; set; }
        [Serializable(2), Bool]
        public bool InTransition { get; set; }
        [Serializable(3), Bool]
        public bool IsAuto { get; set; }
        [Serializable(4), UInt8Range(0, 250)]
        public uint RemainingFrames { get; set; }
    }
}