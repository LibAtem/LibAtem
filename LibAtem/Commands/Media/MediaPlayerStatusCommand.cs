using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("RCPS", 8)]
    public class MediaPlayerStatusCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MediaPlayerId Index { get; set; }
        [Serializable(1), Bool]
        public bool Playing { get; set; }
        [Serializable(2), Bool]
        public bool Loop { get; set; }
        [Serializable(3), Bool]
        public bool AtBeginning { get; set; }
        [Serializable(4), UInt16]
        public uint ClipFrame { get; set; }
    }
}