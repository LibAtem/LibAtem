using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerInputGain, 8)]
    public class AudioMixerInputGainMacroOp : MacroOpBase
    {
        [CommandId]
        [Serialize(4), Enum16]
        [MacroField("Input")]
        public AudioSource Index { get; set; }

        [Serialize(6), Decibels]
        [MacroField("Gain")]
        public double Gain { get; set; }

        public override ICommand ToCommand()
        {
            return new AudioMixerInputSetCommand()
            {
                Mask = AudioMixerInputSetCommand.MaskFlags.Gain,
                Index = Index,
                Gain = Gain,
            };
        }
    }
}