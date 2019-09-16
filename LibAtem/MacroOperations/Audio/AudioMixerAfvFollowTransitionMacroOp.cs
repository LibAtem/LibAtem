using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerAfvFollowTransition, 8)]
    public class AudioMixerAfvFollowTransitionMacroOp : MacroOpBase
    {
        [Serialize(4), Bool]
        [MacroField("Enable")]
        public bool Enable { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new AudioMixerPropertiesSetCommand
            {
                Mask = AudioMixerPropertiesSetCommand.MaskFlags.AudioFollowVideo,
                AudioFollowVideo = Enable,
            };
        }
    }
}