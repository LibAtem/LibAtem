using LibAtem.Serialization;
using LibAtem.Common;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXCP", CommandDirection.ToClient, 20)]
    public class HyperDeckPlayerGetCommand : SerializableCommandBase
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

        [Serialize(9), HyperDeckTime]
        public HyperDeckTime TimelineTime { get; set; }

        [Serialize(14), HyperDeckTime]
        public HyperDeckTime ClipTime { get; set; }

    }
}