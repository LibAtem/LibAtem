using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("SCPS", CommandDirection.ToServer, 8)]
    public class MediaPlayerClipStatusSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Playing = 1 << 0,
            Loop = 1 << 1,
            AtBeginning = 1 << 2,
            ClipFrame = 1 << 3,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MediaPlayerId Index { get; set; }
        [Serialize(2), Bool]
        public bool Playing { get; set; }
        [Serialize(3), Bool]
        public bool Loop { get; set; }
        [Serialize(4), Bool]
        public bool AtBeginning { get; set; }
        [Serialize(6), UInt16]
        public uint ClipFrame { get; set; }
    }
}