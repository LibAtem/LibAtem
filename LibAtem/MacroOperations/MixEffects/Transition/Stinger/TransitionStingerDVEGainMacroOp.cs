using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionStingerDVEGain, 12)]
    public class TransitionStingerDVEGainMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Gain")]
        public double Gain { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionStingerSetCommand
            {
                Mask = TransitionStingerSetCommand.MaskFlags.Gain,
                Index = Index,
                Gain = Gain,
            };
        }
    }
}