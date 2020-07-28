using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXSS", CommandDirection.ToClient, 32)]
    public class HyperDeckStorageGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint Id { get; set; }

        [Serialize(8), Int16]
        public int ActiveStorageMedia { get; set; }

        [Serialize(10), Int16]
        public int CurrentClipId { get; set; }

        [Serialize(13), HyperDeckTime]
        public HyperDeckTime RemainingRecordTime { get; set; }

        [Serialize(20), UInt32]
        public uint FrameRate { get; set; }
        [Serialize(24), UInt32]
        public uint TimeScale { get; set; }

        [Serialize(28), Bool]
        public bool IsInterlaced { get; set; }
        [Serialize(29), Bool]
        public bool IsDropFrameTimecode{ get; set; }
    }
}