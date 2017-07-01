using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsL", 4)]
    public class DownstreamKeyOnAirSetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serializable(1), Bool]
        public bool OnAir { get; set; }
    }
}