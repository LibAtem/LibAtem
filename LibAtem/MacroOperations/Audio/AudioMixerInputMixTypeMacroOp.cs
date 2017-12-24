using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerInputMixType, 8)]
    public class AudioMixerInputMixTypeMacroOp : MacroOpBase
    {
        [CommandId]
        [Serialize(4), Enum16]
        [MacroField("Input")]
        public AudioSource Index { get; set; }

        [Serialize(6), Enum8]
        [MacroField("MixType")]
        public AudioMixOption MixOption { get; set; }

        public override ICommand ToCommand()
        {
            return new AudioMixerInputSetCommand()
            {
                Mask = AudioMixerInputSetCommand.MaskFlags.MixOption,
                Index = Index,
                MixOption = MixOption,
            };
        }
    }
}