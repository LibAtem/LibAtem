using System;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Common;

namespace LibAtem.State.Builder
{
    internal static class AudioStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is AudioMixerConfigCommand confCmd)
            {
                state.Audio = new AudioState
                {
                    Monitors = UpdaterUtil.CreateList(confCmd.Monitors, i => new AudioState.MonitorOutputState())
                };
                // TODO - inputs?
                // TODO - more props?
                result.SetSuccess("Audio.Monitors");
            } else if (state.Audio != null) { 
                if (command is AudioMixerMasterGetCommand masterCmd)
                {
                    UpdaterUtil.CopyAllProperties(masterCmd, state.Audio.ProgramOut, null,
                        new[] {"Levels"});
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
                else if (command is AudioMixerInputGetV8Command input8Cmd)
                {
                    if (!state.Audio.Inputs.ContainsKey((int)input8Cmd.Index)) state.Audio.Inputs[(int)input8Cmd.Index] = new AudioState.InputState();

                    UpdaterUtil.TryForKey(result, state.Audio.Inputs, (long)input8Cmd.Index, input =>
                    {
                        UpdaterUtil.CopyAllProperties(input8Cmd, input.Properties, new[] { "Index", "IndexOfSourceType" });
                        result.SetSuccess($"Audio.Inputs.{input8Cmd.Index:D}.Properties");
                    });
                }
                else if (command is AudioMixerInputGetCommand inputCmd)
                {
                    if (!state.Audio.Inputs.ContainsKey((int)inputCmd.Index)) state.Audio.Inputs[(int)inputCmd.Index] = new AudioState.InputState();

                    UpdaterUtil.TryForKey(result, state.Audio.Inputs, (long)inputCmd.Index, input =>
                    {
                        UpdaterUtil.CopyAllProperties(inputCmd, input.Properties, new[] { "Index", "IndexOfSourceType" });
                        result.SetSuccess($"Audio.Inputs.{inputCmd.Index:D}.Properties");
                    });
                }
                else if (command is AudioMixerLevelsCommand levelsCmd)
                {
                    var paths = new List<string>(new[] {"Audio.ProgramOut.Levels"});
                    state.Audio.ProgramOut.Levels = new AudioState.LevelsState
                    {
                        Levels = new[] {levelsCmd.MasterLeftLevel, levelsCmd.MasterRightLevel},
                        Peaks = new[] {levelsCmd.MasterLeftPeak, levelsCmd.MasterRightPeak},
                    };

                    foreach (AudioMixerLevelInput inputLevels in levelsCmd.Inputs)
                    {
                        UpdaterUtil.TryForKey(result, state.Audio.Inputs, (long)inputLevels.Source, input =>
                        {
                            paths.Add($"Audio.Inputs.{inputLevels.Source:D}.Levels");
                            input.Levels = new AudioState.LevelsState
                            {
                                Levels = new[] { inputLevels.LeftLevel, inputLevels.RightLevel },
                                Peaks = new[] { inputLevels.LeftPeak, inputLevels.RightPeak },
                            };
                        });
                    }

                    result.SetSuccess(paths);
                }
                else if (command is AudioMixerTallyCommand tallyCmd)
                {
                    state.Audio.Tally = tallyCmd.Inputs;
                    result.SetSuccess($"Audio.Tally");
                }
            }
        }
    }
}