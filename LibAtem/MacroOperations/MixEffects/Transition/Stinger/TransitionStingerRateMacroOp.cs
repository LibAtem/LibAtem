using LibAtem.Commands;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionStingerRate, 8)]
    public class TransitionStingerRateMacroOp : TransitionRateMacroOpBase
    {
        public override ICommand ToCommand()
        {
            return null; // TODO - no Rate prop on command currently
//            return new TransitionStingerSetCommand()
//            {
//                Mask = TransitionStingerSetCommand.MaskFlags.Rate,
//                Index = Index,
//                Rate = Rate,
//            };
        }
    }
}