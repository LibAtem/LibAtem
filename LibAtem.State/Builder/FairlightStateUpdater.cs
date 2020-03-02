using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.Audio.Fairlight;
using LibAtem.Commands.DeviceProfile;

namespace LibAtem.State.Builder
{
    internal static class FairlightStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is FairlightAudioMixerConfigCommand confCmd)
            {
                state.Fairlight = new FairlightAudioState
                {
                    Monitors = UpdaterUtil.CreateList(confCmd.Monitors,
                        i => new FairlightAudioState.MonitorOutputState()),
                };
                result.SetSuccess("Fairlight.Monitors");
            }
            else if (state.Fairlight != null)
            {
                if (command is FairlightMixerMasterGetCommand masterCmd)
                {
                    var pgmState = state.Fairlight.ProgramOut;
                    UpdaterUtil.CopyAllProperties(masterCmd, pgmState,
                        new[] { "EqualizerGain", "EqualizerEnabled", "MakeUpGain" },
                        new[] { "Dynamics", "Equalizer", "AudioFollowVideoCrossfadeTransitionEnabled", "Levels", "Peaks" });

                    pgmState.Dynamics.MakeUpGain = masterCmd.MakeUpGain;
                    pgmState.Equalizer.Enabled = masterCmd.EqualizerEnabled;
                    pgmState.Equalizer.Gain = masterCmd.EqualizerGain;

                    result.SetSuccess(new[]
                    {
                        "Fairlight.ProgramOut",
                        "Fairlight.ProgramOut.Dynamics",
                        "Fairlight.ProgramOut.Equalizer"
                    });
                }
                else if (command is FairlightMixerMasterLimiterGetCommand masterLimCmd)
                {
                    var pgmDynamics = state.Fairlight.ProgramOut.Dynamics;
                    if (pgmDynamics.Limiter == null) pgmDynamics.Limiter = new FairlightAudioState.LimiterState();

                    UpdaterUtil.CopyAllProperties(masterLimCmd, pgmDynamics.Limiter, null, new[] { "GainReductionLevel" });
                    result.SetSuccess("Fairlight.ProgramOut.Dynamics.Limiter");
                }
                else if (command is FairlightMixerMasterCompressorGetCommand masterCompCmd)
                {
                    var pgmDynamics = state.Fairlight.ProgramOut.Dynamics;
                    if (pgmDynamics.Compressor == null) pgmDynamics.Compressor = new FairlightAudioState.CompressorState();

                    UpdaterUtil.CopyAllProperties(masterCompCmd, pgmDynamics.Compressor, null, new[] { "GainReductionLevel" });
                    result.SetSuccess("Fairlight.ProgramOut.Dynamics.Compressor");
                }
                else if (command is FairlightMixerInputGetCommand inpCmd)
                {
                    if (!state.Fairlight.Inputs.TryGetValue((long)inpCmd.Index, out var inputState))
                        inputState = state.Fairlight.Inputs[(long)inpCmd.Index] = new FairlightAudioState.InputState();

                    UpdaterUtil.CopyAllProperties(inpCmd, inputState, new[] { "Index" },
                        new[] { "Sources", "Analog", "Xlr" });
                    result.SetSuccess(new[]
                    {
                        $"Fairlight.Inputs.{inpCmd.Index:D}.ExternalPortType",
                        $"Fairlight.Inputs.{inpCmd.Index:D}.ActiveConfiguration"
                    });
                }
                else if (command is FairlightMixerSourceGetCommand srcCmd)
                {
                    UpdaterUtil.TryForKey(result, state.Fairlight.Inputs, (long)srcCmd.Index, inputState =>
                    {
                        FairlightAudioState.InputSourceState srcState = inputState.Sources.FirstOrDefault(s => s.SourceId == srcCmd.SourceId);
                        if (srcState == null)
                        {
                            srcState = new FairlightAudioState.InputSourceState();
                            inputState.Sources.Add(srcState);
                        }

                        srcState.Dynamics.MakeUpGain = srcCmd.MakeUpGain;
                        srcState.Equalizer.Enabled = srcCmd.EqualizerEnabled;
                        srcState.Equalizer.Gain = srcCmd.EqualizerGain;

                        UpdaterUtil.CopyAllProperties(srcCmd, srcState,
                            new[] { "Index", "EqualizerEnabled", "EqualizerGain", "MakeUpGain" },
                            new[] { "Dynamics", "Equalizer", "Levels" });
                        result.SetSuccess($"Fairlight.Inputs.{srcCmd.Index:D}.Sources.{srcCmd.SourceId:D}");
                    });
                }
                else if (command is FairlightMixerSourceDeleteCommand delCmd)
                {
                    UpdaterUtil.TryForKey(result, state.Fairlight.Inputs, (long)delCmd.Index, inputState =>
                   {
                       inputState.Sources.RemoveAll(src => src.SourceId == delCmd.SourceId);
                       result.SetSuccess($"Fairlight.Inputs.{delCmd.Index:D}.Sources.{delCmd.SourceId:D}");
                   });
                }
                else if (command is FairlightMixerSourceCompressorGetCommand compCmd)
                {
                    UpdaterUtil.TryForKey(result, state.Fairlight.Inputs, (long)compCmd.Index, inputState =>
                    {
                        FairlightAudioState.InputSourceState srcState = inputState.Sources.FirstOrDefault(s => s.SourceId == compCmd.SourceId);
                        if (srcState != null)
                        {
                            if (srcState.Dynamics.Compressor == null)
                                srcState.Dynamics.Compressor = new FairlightAudioState.CompressorState();

                            UpdaterUtil.CopyAllProperties(compCmd, srcState.Dynamics.Compressor, new[] { "Index", "SourceId" }, new[] { "GainReductionLevel" });
                            result.SetSuccess($"Fairlight.Inputs.{compCmd.Index:D}.Sources.{compCmd.SourceId:D}.Dynamics.Compressor");
                        }
                    });
                }
                else if (command is FairlightMixerSourceLimiterGetCommand limCmd)
                {
                    UpdaterUtil.TryForKey(result, state.Fairlight.Inputs, (long)limCmd.Index, inputState =>
                    {
                        FairlightAudioState.InputSourceState srcState = inputState.Sources.FirstOrDefault(s => s.SourceId == limCmd.SourceId);
                        if (srcState != null)
                        {
                            if (srcState.Dynamics.Limiter == null)
                                srcState.Dynamics.Limiter = new FairlightAudioState.LimiterState();

                            UpdaterUtil.CopyAllProperties(limCmd, srcState.Dynamics.Limiter, new[] { "Index", "SourceId" }, new[] { "GainReductionLevel" });
                            result.SetSuccess($"Fairlight.Inputs.{limCmd.Index:D}.Sources.{limCmd.SourceId:D}.Dynamics.Limiter");
                        }
                    });
                }
                else if (command is FairlightMixerSourceExpanderGetCommand expandCmd)
                {
                    UpdaterUtil.TryForKey(result, state.Fairlight.Inputs, (long)expandCmd.Index, inputState =>
                    {
                        FairlightAudioState.InputSourceState srcState = inputState.Sources.FirstOrDefault(s => s.SourceId == expandCmd.SourceId);
                        if (srcState != null)
                        {
                            if (srcState.Dynamics.Expander == null)
                                srcState.Dynamics.Expander = new FairlightAudioState.ExpanderState();

                            UpdaterUtil.CopyAllProperties(expandCmd, srcState.Dynamics.Expander, new[] { "Index", "SourceId" }, new[] { "GainReductionLevel" });
                            result.SetSuccess($"Fairlight.Inputs.{expandCmd.Index:D}.Sources.{expandCmd.SourceId:D}.Dynamics.Expander");
                        }
                    });
                }
                else if (command is FairlightMixerAnalogAudioGetCommand analogCmd)
                {
                    UpdaterUtil.TryForKey(result, state.Fairlight.Inputs, (long)analogCmd.Index, inputState =>
                    {
                        if (inputState.Analog == null) inputState.Analog = new FairlightAudioState.AnalogState();

                        UpdaterUtil.CopyAllProperties(analogCmd, inputState.Analog, new[] { "Index" });
                        result.SetSuccess($"Fairlight.Inputs.{analogCmd.Index:D}.Analog");
                    });
                }
                else if (command is FairlightMixerMonitorGetCommand monCmd)
                {
                    UpdaterUtil.TryForIndex(result, state.Fairlight.Monitors, 0, monState =>
                    {
                        UpdaterUtil.CopyAllProperties(monCmd, monState, new[] { "Index" });
                        result.SetSuccess($"Fairlight.Monitors.{0:D}");
                    });
                }
                else if (command is FairlightMixerMasterPropertiesGetCommand master2Cmd)
                {
                    state.Fairlight.ProgramOut.AudioFollowVideoCrossfadeTransitionEnabled =
                        master2Cmd.AudioFollowVideoCrossfadeTransitionEnabled;
                    result.SetSuccess($"Fairlight.ProgramOut");
                }
                else if (command is FairlightMixerMasterLevelsCommand pgmLevelCmd)
                {
                    FairlightAudioState.ProgramOutState pgmOutState = state.Fairlight.ProgramOut;
                    pgmOutState.Levels = new FairlightAudioState.LevelsState
                    {
                        Levels = new[] { pgmLevelCmd.LeftLevel, pgmLevelCmd.RightLevel },
                        Peaks = new[] { pgmLevelCmd.LeftPeak, pgmLevelCmd.RightPeak },

                        DynamicsInputLevels = new[] { pgmLevelCmd.InputLeftLevel, pgmLevelCmd.InputRightLevel },
                        DynamicsInputPeaks = new[] { pgmLevelCmd.InputLeftPeak, pgmLevelCmd.InputRightPeak },
                        DynamicsOutputLevels = new[] { pgmLevelCmd.OutputLeftLevel, pgmLevelCmd.OutputRightLevel },
                        DynamicsOutputPeaks = new[] { pgmLevelCmd.OutputLeftPeak, pgmLevelCmd.OutputRightPeak },

                        CompressorGainReductionLevel = pgmLevelCmd.CompressorGainReduction,
                        LimiterGainReductionLevel = pgmLevelCmd.LimiterGainReduction,
                    };

                    result.SetSuccess($"Fairlight.ProgramOut.Levels");
                }
                else if (command is FairlightMixerSourceLevelsCommand srcLevelCmd)
                {
                    UpdaterUtil.TryForKey(result, state.Fairlight.Inputs, (long)srcLevelCmd.Index, inputState =>
                    {
                        FairlightAudioState.InputSourceState srcState = inputState.Sources.FirstOrDefault(s => s.SourceId == srcLevelCmd.SourceId);
                        if (srcState != null)
                        {
                            srcState.Levels = new FairlightAudioState.LevelsState
                            {
                                Levels = new[] { srcLevelCmd.LeftLevel, srcLevelCmd.RightLevel },
                                Peaks = new[] { srcLevelCmd.LeftPeak, srcLevelCmd.RightPeak },

                                DynamicsInputLevels = new[] { srcLevelCmd.InputLeftLevel, srcLevelCmd.InputRightLevel },
                                DynamicsInputPeaks = new[] { srcLevelCmd.InputLeftPeak, srcLevelCmd.InputRightPeak },
                                DynamicsOutputLevels = new[] { srcLevelCmd.OutputLeftLevel, srcLevelCmd.OutputRightLevel },
                                DynamicsOutputPeaks = new[] { srcLevelCmd.OutputLeftPeak, srcLevelCmd.OutputRightPeak },

                                CompressorGainReductionLevel = srcLevelCmd.CompressorGainReduction,
                                LimiterGainReductionLevel = srcLevelCmd.LimiterGainReduction,
                                ExpanderGainReductionLevel = srcLevelCmd.ExpanderGainReduction,
                            };

                            result.SetSuccess($"Fairlight.Inputs.{srcLevelCmd.Index:D}.Sources.{srcLevelCmd.SourceId:D}.Levels");
                        }
                    });
                }
                else if (command is FairlightMixerTallyCommand tallyCmd)
                {
                    state.Fairlight.Tally = tallyCmd.Tally;
                    result.SetSuccess("Fairlight.Tally");
                }
            }
        }
    }
}