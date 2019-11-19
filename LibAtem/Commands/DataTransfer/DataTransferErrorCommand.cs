using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTDE", CommandDirection.ToClient, 4)]
    public class DataTransferErrorCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }

        [Serialize(2), UInt8]
        public uint ErrorCode { get; set; }
    }
}