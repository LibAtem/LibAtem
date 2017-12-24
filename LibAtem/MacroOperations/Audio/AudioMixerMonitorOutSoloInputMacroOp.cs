using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerMonitorOutSoloInput, 8)]
    public class AudioMixerMonitorOutSoloInputMacroOp : MacroOpBase
    {
        [Serialize(4), Enum16]
        [MacroField("Input")]
        public AudioSource Input { get; set; }

        public override ICommand ToCommand()
        {
            return new AudioMixerMonitorSetCommand
            {
                Mask = AudioMixerMonitorSetCommand.MaskFlags.SoloSource,
                SoloSource = Input,
            };
        }
    }
}