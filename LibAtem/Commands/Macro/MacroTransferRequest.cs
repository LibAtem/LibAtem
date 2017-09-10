using LibAtem.Serialization;

namespace LibAtem.Commands.Macro
{
    [CommandName("FTSU", 12)]
    public class MacroTransferRequestCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }
        
        [Serialize(2), UInt8]
        public uint TransferStoreId { get; set; }

        [Serialize(7), UInt8]
        public uint TransferIndex { get; set; }
    }
}