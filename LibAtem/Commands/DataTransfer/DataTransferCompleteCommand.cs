using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTDC", CommandDirection.Both, 4)]
    public class DataTransferCompleteCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }
    }
}