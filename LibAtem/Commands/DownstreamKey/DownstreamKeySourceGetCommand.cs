using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DskB", 8)]
    public class DownstreamKeySourceGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serializable(2), Enum16]
        public VideoSource FillSource { get; set; }
        [Serializable(4), Enum16]
        public VideoSource CutSource { get; set; }
    }
}