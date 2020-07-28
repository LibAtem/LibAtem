using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("CXCP", CommandDirection.ToServer, 20)]
    public class HyperDeckPlayerSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            State = 1 << 0,
            SingleClip = 1 << 1,
            Loop = 1 << 2,
            PlaybackSpeed = 1 << 3,
            ClipTime = 1 << 4,
            Jog = 1 << 5,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(2), UInt16]
        public uint Id { get; set; }

        [Serialize(4), Enum8]
        public HyperDeckPlayerState State { get; set; }
        [Serialize(5), Bool]
        public bool SingleClip { get; set; }
        [Serialize(6), Bool]
        public bool Loop { get; set; }
        [Serialize(8), Int16]
        public int PlaybackSpeed { get; set; }

        [Serialize(11), HyperDeckTime]
        public HyperDeckTime ClipTime { get; set; }

        [Serialize(15), DirectionInt32]
        public int Jog { get; set; }
    }
}