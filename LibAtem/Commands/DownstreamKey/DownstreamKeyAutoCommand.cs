using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DDsA", 4)]
    public class DownstreamKeyAutoCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public DownstreamKeyId Index { get; set; }
    }
}