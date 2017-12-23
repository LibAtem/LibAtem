using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionStingerSourceMediaPlayer, 8)]
    public class TransitionStingerSourceMediaPlayerMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Enum8]
        [MacroField("MediaPlayer")]
        public StingerSource Source { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionStingerSetCommand
            {
                Mask = TransitionStingerSetCommand.MaskFlags.Source,
                Index = Index,
                Source = Source,
            };
        }
    }
}