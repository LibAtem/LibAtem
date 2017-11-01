using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionWipePattern, 8)]
    public class TransitionWipePatternMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Enum8]
        [MacroField("Pattern")]
        public Pattern Pattern { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionWipeSetCommand
            {
                Mask = TransitionWipeSetCommand.MaskFlags.Pattern,
                Index = Index,
                Pattern = Pattern,
            };
        }
    }
}