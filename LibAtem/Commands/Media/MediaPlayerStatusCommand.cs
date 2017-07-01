using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("RCPS", 8)]
    public class MediaPlayerStatusCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MediaPlayerId Index { get; set; }
        [Serialize(1), Bool]
        public bool Playing { get; set; }
        [Serialize(2), Bool]
        public bool Loop { get; set; }
        [Serialize(3), Bool]
        public bool AtBeginning { get; set; }
        [Serialize(4), UInt16]
        public uint ClipFrame { get; set; }
    }
}