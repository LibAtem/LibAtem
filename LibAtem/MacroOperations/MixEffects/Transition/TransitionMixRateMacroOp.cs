using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionMixRate, 8)]
    public class TransitionMixRateMacroOp : TransitionRateMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionMixSetCommand()
            {
                Index = Index,
                Rate = Rate,
            };
        }
    }
}