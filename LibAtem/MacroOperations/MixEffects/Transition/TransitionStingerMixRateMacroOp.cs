using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionStingerMixRate, 8)]
    public class TransitionStingerMixRateMacroOp : TransitionRateMacroOpBase
    {
        public override ICommand ToCommand()
        {
            return new TransitionStingerSetCommand()
            {
                Mask = TransitionStingerSetCommand.MaskFlags.MixRate,
                Index = Index,
                MixRate = Rate,
            };
        }
    }
}