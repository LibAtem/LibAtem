using System;
using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Commands.DeviceProfile;

namespace LibAtem.State.Builder
{
    internal static class AudioStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is AudioMixerConfigCommand confCmd)
            {
                state.Audio.Monitors =
                    UpdaterUtil.CreateList(confCmd.Monitors, i => new AudioState.MonitorOutputState());
                // TODO - inputs?
                // TODO - more props?
                result.SetSuccess("Audio.Monitors");
            }
            else if (command is AudioMixerMasterGetCommand masterCmd)
            {
                UpdaterUtil.CopyAllProperties(masterCmd, state.Audio.ProgramOut, null,
                    new[] {"LevelLeft", "LevelRight", "PeakLeft", "PeakRight"});
                result.SetSuccess("Audio.ProgramOut");
            }
            else if (command is AudioMixerMonitorGetCommand monCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Audio.Monitors, 0, mon => // TODO - dynamic index
                {
                    UpdaterUtil.CopyAllProperties(monCmd, mon);
                    result.SetSuccess("Audio.Monitors.0");
                });
            }
            else if (command is AudioMixerTalkbackPropertiesGetCommand talkbackCmd)
            {
                UpdaterUtil.CopyAllProperties(talkbackCmd, state.Audio.Talkback, null, new[] {"Inputs"});
                result.SetSuccess("Audio.Talkback");
            }
            else if (command is AudioMixerInputGetCommand inputCmd)
            {
                /* TODO - verify/test this
                UpdaterUtil.TryForKey(result, state.Audio.Inputs, (long) inputCmd.Index, input =>
                {
                    UpdaterUtil.CopyAllProperties(inputCmd, input);
                    result.SetSuccess($"Audio.Inputs.{inputCmd.Index}");
                });
                */
            }
        }
    }
}