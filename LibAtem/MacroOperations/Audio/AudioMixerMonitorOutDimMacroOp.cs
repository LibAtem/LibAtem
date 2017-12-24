using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerMonitorOutDim, 8)]
    public class AudioMixerMonitorOutDimMacroOp : MacroOpBase
    {
        [Serialize(4), Bool]
        [MacroField("Dim")]
        public bool Dim { get; set; }

        public override ICommand ToCommand()
        {
            return new AudioMixerMonitorSetCommand
            {
                Mask = AudioMixerMonitorSetCommand.MaskFlags.Dim,
                Dim = Dim,
            };
        }
    }
}