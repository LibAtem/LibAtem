using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsF", 4)]
    public class DownstreamKeyFillSourceSetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serializable(2), Enum16]
        public VideoSource Source { get; set; }
    }
}