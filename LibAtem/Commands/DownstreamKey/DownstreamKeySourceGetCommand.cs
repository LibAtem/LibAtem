using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DskB", 8)]
    public class DownstreamKeySourceGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serialize(2), Enum16]
        public VideoSource FillSource { get; set; }
        [Serialize(4), Enum16]
        public VideoSource CutSource { get; set; }
    }
}