using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations
{
    [MacroOperation(MacroOperationType.AuxiliaryInput, 8)]
    public class AuxiliaryInputMacroOp : MacroOpBase
    {
        [CommandId]
        [Serialize(4), UInt16]
        [MacroField("AuxiliaryIndex")]
        public uint Index { get; set; }

        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new AuxSourceSetCommand()
            {
                Id = Index,
                Source = Source,
            };
        }
    }
}
    