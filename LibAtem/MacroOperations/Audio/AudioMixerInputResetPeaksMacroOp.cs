using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerInputResetPeaks, 8)]
    public class AudioMixerInputResetPeaksMacroOp : MacroOpBase
    {
        [Serialize(4), Enum16]
        [MacroField("Input")]
        public AudioSource Input { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new AudioMixerResetPeaksCommand
            {
                Mask = AudioMixerResetPeaksCommand.MaskFlags.Input,
                Input = Input,
            };
        }
    }
}