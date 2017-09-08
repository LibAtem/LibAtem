using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionDVERate, 8)]
    public class TransitionDVERateMacroOp : TransitionRateMacroOpBase
    {
        public override ICommand ToCommand()
        {
            return new TransitionDVESetCommand()
            {
                Mask = TransitionDVESetCommand.MaskFlags.Rate,
                Index = Index,
                Rate = Rate,
            };
        }
    }
}