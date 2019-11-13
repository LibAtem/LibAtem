using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Transition.Wipe
{
    [MacroOperation(MacroOperationType.TransitionWipeRate, 8)]
    public class TransitionWipeRateMacroOp : TransitionRateMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionWipeSetCommand()
            {
                Mask = TransitionWipeSetCommand.MaskFlags.Rate,
                Index = Index,
                Rate = Rate,
            };
        }
    }
}