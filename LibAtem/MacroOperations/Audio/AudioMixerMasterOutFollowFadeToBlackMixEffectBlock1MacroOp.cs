using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1, 8)]
    public class AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp : MacroOpBase
    {
        [Serialize(4), Bool]
        [MacroField("Follow")]
        public bool Follow { get; set; }

        public override ICommand ToCommand()
        {
            return new AudioMixerMasterSetCommand()
            {
                Mask = AudioMixerMasterSetCommand.MaskFlags.FollowFadeToBlack,
                FollowFadeToBlack = Follow,
            };
        }
    }
}