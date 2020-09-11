using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    public enum DataTransferError
    {
        TryAgain = 1,
        NotFound = 2,
    }
    
    [CommandName("FTDE", CommandDirection.ToClient, 4)]
    public class DataTransferErrorCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }

        [Serialize(2), Enum8]
        public DataTransferError ErrorCode { get; set; }
    }
}