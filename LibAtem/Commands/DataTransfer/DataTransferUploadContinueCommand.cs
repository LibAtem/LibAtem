using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTCD", 12)] // Client to Server
    public class DataTransferUploadContinueCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }
        
        [Serialize(2), UInt8]
        public uint Unknown => 26; // TODO - why this number?

        [Serialize(6), UInt16]
        public uint ChunkSize { get; set; }

        [Serialize(8), UInt16]
        public uint ChunkCount { get; set; }

        [Serialize(10), UInt16]
        public uint Test3 => 0x8b00;
    }
}