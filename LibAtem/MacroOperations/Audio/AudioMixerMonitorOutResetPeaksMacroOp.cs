using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Common;

namespace LibAtem.MacroOperations.Audio
{
    [MacroOperation(MacroOperationType.AudioMixerMonitorOutResetPeaks, 4), NoMacroFields]
    public class AudioMixerMonitorOutResetPeaksMacroOp : MacroOpBase
    {
        public override ICommand ToCommand()
        {
            return new AudioMixerResetPeaksCommand
            {
                Mask = AudioMixerResetPeaksCommand.MaskFlags.Monitor,
            };
        }
    }
}