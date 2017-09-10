using LibAtem.Serialization;

namespace LibAtem.Commands.Macro
{
    [CommandName("FTDC", 4)]
    public class MacroTransferCompleteCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint TransferId { get; set; }
    }
}