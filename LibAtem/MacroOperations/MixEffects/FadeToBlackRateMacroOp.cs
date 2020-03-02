using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Common;
using LibAtem.MacroOperations.MixEffects.Transition;

namespace LibAtem.MacroOperations.MixEffects
{
    [MacroOperation(MacroOperationType.FadeToBlackRate, 8)]
    public class FadeToBlackRateMacroOp : TransitionRateMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new FadeToBlackRateSetCommand()
            {
                Index = Index,
                Rate = Rate,
            };
        }
    }
}