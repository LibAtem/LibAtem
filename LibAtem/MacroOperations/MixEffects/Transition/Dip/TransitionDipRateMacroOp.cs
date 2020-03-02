using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Transition.Dip
{
    [MacroOperation(MacroOperationType.TransitionDipRate, 8)]
    public class TransitionDipRateMacroOp : TransitionRateMacroOpBase
    {
        public override ICommand ToCommand(ProtocolVersion version)
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