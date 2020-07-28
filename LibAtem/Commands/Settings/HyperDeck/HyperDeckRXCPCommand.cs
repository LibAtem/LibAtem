using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{
    public enum HyperDeckPlayerState
    {
        Idle = 1,
        Playing = 0,
        Shuttle = 2,
        Recording = 4,
        // Unknown = 6, // TODO
    }

    [CommandName("CXCP", CommandDirection.ToServer, 20)]
    public class HyperDeckCXCPCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            State = 1 << 0,
            SingleClip = 1 << 1,
            Loop = 1 << 2,
            PlaybackSpeed = 1 << 3,

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

        [Serialize(12), Int8]
        public int Jog { get; set; }

    }

    [CommandName("RXCP", CommandDirection.ToClient, 20)]
    public class HyperDeckRXCPCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint Id { get; set; }

        [Serialize(2), Enum8]
        public HyperDeckPlayerState State { get; set; }
        [Serialize(3), Bool]
        public bool SingleClip { get; set; }
        [Serialize(4), Bool]
        public bool Loop { get; set; }
        [Serialize(6), Int16]
        public int PlaybackSpeed { get; set; }
    }
}