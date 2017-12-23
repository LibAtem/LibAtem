using LibAtem.Commands;
using LibAtem.Common;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionStingerResetDurations, 8)]
    public class TransitionStingerResetDurationsMacroOp : MixEffectMacroOpBase
    {
        public override ICommand ToCommand()
        {
            return null; // TODO should this do anything?
//            return new TransitionStingerSetCommand
//            {
//                Mask = TransitionStingerSetCommand.MaskFlags.Durations,
//                Index = Index,
//                Preroll = 0,
//                ClipDuration = 0, // TODO - should this be set to the mp duration?
//                TriggerPoint = 0,
//                MixRate = 0,
//            };
        }
    }
}