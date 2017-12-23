using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionStingerDVEClip, 12)]
    public class TransitionStingerDVEClipMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Clip")]
        public double Clip { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionStingerSetCommand
            {
                Mask = TransitionStingerSetCommand.MaskFlags.Clip,
                Index = Index,
                Clip = Clip,
            };
        }
    }
}