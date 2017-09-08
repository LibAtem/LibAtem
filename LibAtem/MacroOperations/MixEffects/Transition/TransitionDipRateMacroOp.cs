using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionDipRate, 8)]
    public class TransitionDipRateMacroOp : TransitionRateMacroOpBase
    {
        public override ICommand ToCommand()
        {
            return new TransitionDipSetCommand()
            {
                Mask = TransitionDipSetCommand.MaskFlags.Rate,
                Index = Index,
                Rate = Rate,
            };
        }
    }
}