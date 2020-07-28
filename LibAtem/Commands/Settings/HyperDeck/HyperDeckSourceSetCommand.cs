using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("CXSS", CommandDirection.ToServer, 8)]
    public class HyperDeckSourceSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            ActiveStorageMedia = 1 << 0,
            CurrentClipId = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(2), UInt16]
        public uint Id { get; set; }

        [Serialize(4), Int16]
        public int ActiveStorageMedia { get; set; }

        [Serialize(6), Int16]
        public int CurrentClipId { get; set; }
    }
}