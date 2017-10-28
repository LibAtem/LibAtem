using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTSU", 12)] // Server to Client
    public class DataTransferDownloadRequestCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }
        
        [Serialize(2), UInt16]
        public uint TransferStoreId { get; set; }

        [Serialize(7), UInt8]
        public uint TransferIndex { get; set; }

        [Serialize(8), UInt16]
        public uint Unknown { get; set; } = 0x03f7;
    }
}