using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects
{
    [MacroOperation(MacroOperationType.ProgramInput, 8)]
    public class ProgramInputMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Source { get; set; }

        public override ICommand ToCommand()
        {
            return new ProgramInputSetCommand()
            {
                Index = Index,
                Source = Source,
            };
        }
    }
}