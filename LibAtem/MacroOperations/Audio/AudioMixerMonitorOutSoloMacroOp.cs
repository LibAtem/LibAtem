using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerMonitorOutSolo, 8)]
    public class AudioMixerMonitorOutSoloMacroOp : MacroOpBase
    {
        [Serialize(4), Bool]
        [MacroField("Solo")]
        public bool Solo { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new AudioMixerMonitorSetCommand
            {
                Mask = AudioMixerMonitorSetCommand.MaskFlags.Solo,
                Solo = Solo,
            };
        }
    }
}