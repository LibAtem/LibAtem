using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects
{
    [MacroOperation(MacroOperationType.PreviewInput, 8)]
    public class PreviewInputMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new PreviewInputSetCommand()
            {
                Index = Index,
                Source = Source,
            };
        }
    }
}