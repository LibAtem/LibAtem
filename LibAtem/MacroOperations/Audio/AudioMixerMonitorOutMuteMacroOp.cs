using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerMonitorOutMute, 8)]
    public class AudioMixerMonitorOutMuteMacroOp : MacroOpBase
    {
        [Serialize(4), Bool]
        [MacroField("Mute")]
        public bool Mute { get; set; }

        public override ICommand ToCommand()
        {
            return new AudioMixerMonitorSetCommand
            {
                Mask = AudioMixerMonitorSetCommand.MaskFlags.Mute,
                Mute = Mute,
            };
        }
    }
}