using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Transition.DVE
{
    [MacroOperation(MacroOperationType.TransitionDVERate, 8)]
    public class TransitionDVERateMacroOp : TransitionRateMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
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