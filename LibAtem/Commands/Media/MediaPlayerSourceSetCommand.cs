using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("MPSS", 8)]
    public class MediaPlayerSourceSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            SourceType = 1 << 0,
            StillIndex = 1 << 1,
            ClipIndex = 1 << 2,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serialize(1), Enum8]
        public MediaPlayerId Index { get; set; }
        [Serialize(2), Enum8]
        public MediaPlayerSource SourceType { get; set; }
        [Serialize(3), UInt8]
        public uint ClipIndex { get; set; }
        [Serialize(4), UInt8]
        public uint StillIndex { get; set; }
    }
}