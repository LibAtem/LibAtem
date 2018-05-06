using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTFD", 212)]
    public class DataTransferFileDescriptionCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }

        [Serialize(2), String(20)]
        public string Name { get; set; }

        [Serialize(66), String(128)]
        public string Description { get; set; }

        [Serialize(194), ByteArray(16)]
        public byte[] FileHash { get; set; }
    }
}