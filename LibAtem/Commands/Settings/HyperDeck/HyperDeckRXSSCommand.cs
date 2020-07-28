using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.HyperDeck
{
    [CommandName("RXSS", CommandDirection.ToClient, 32)]
    public class HyperDeckRXSSCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint Id { get; set; }


        [Serialize(8), Int16]
        public int ActiveStorageMedia { get; set; }

        /*
        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(Id);
            cmd.AddByte(0x52, 0x65, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x10, 0xA4, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x62, 0x61);
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Id = cmd.GetUInt16();
            cmd.Skip(32);
        }
        */
    }

    [CommandName("CXSS", CommandDirection.ToServer, 8)]
    public class HyperDeckCXSSCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            ActiveStorageMedia = 1 << 0,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(2), UInt16]
        public uint Id { get; set; }

        [Serialize(4), Int16]
        public int ActiveStorageMedia { get; set; }
    }
}