using LibAtem.Serialization;

namespace LibAtem.Commands.Macro
{
    [CommandName("FTUA", 4)]
    public class MacroTransferAckCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }

        [Serialize(2), UInt8]
        public uint TransferIndex { get; set; }
    }
}