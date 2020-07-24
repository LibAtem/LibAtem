using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTSU", CommandDirection.ToClient, 12)] // Server to Client
    public class DataTransferDownloadRequestCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }
        
        [Serialize(2), UInt16]
        public uint TransferStoreId { get; set; }

        [Serialize(6), UInt16]
        public uint TransferIndex { get; set; }

        [Serialize(8), UInt16]
        public uint Unknown { get; set; } = 0x00f9;
        [Serialize(10), UInt16]
        public uint Unknown2 { get; set; } = 0x020f;
    }
}