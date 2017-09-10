using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTCD", 12)] // Client to Server
    public class DataTransferUploadContinueCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }
        
        [Serialize(9), UInt8]
        public uint Count { get; set; }
    }
}