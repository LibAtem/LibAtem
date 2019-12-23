using System.Collections.Generic;
using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.Audio.Fairlight;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Common;

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
                    // Inputs = UpdaterUtil.CreateList(confCmd.Inputs, i => new FairlightAudioState.InputState()),
                };
                // TODO - inputs?
                // TODO - more props?
                result.SetSuccess("Fairlight.Monitors");
            } else if (state.Fairlight != null)
            {
                if (command is FairlightMixerMasterGetCommand masterCmd)
                {
                    var pgmState = state.Fairlight.ProgramOut;
                    UpdaterUtil.CopyAllProperties(masterCmd, pgmState,
                        new[] {"EqualizerGain", "EqualizerEnabled", "MakeUpGain"}, new []{"Dynamics", "Equalizer"});

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

                    UpdaterUtil.CopyAllProperties(masterLimCmd, pgmDynamics.Limiter);
                    result.SetSuccess("Fairlight.ProgramOut.Dynamics.Limiter");
                }
                else if (command is FairlightMixerMasterCompressorGetCommand masterCompCmd)
                {
                    var pgmDynamics = state.Fairlight.ProgramOut.Dynamics;
                    if (pgmDynamics.Compressor == null) pgmDynamics.Compressor = new FairlightAudioState.CompressorState();

                    UpdaterUtil.CopyAllProperties(masterCompCmd, pgmDynamics.Compressor);
                    result.SetSuccess("Fairlight.ProgramOut.Dynamics.Compressor");
                }
                else if (command is FairlightMixerInputGetCommand inpCmd)
                {
                    if (!state.Fairlight.Inputs.TryGetValue((long) inpCmd.Index, out var inputState))
                        inputState = state.Fairlight.Inputs[(long) inpCmd.Index] = new FairlightAudioState.InputState();

                    var changes = new List<string>
                    {
                        $"Fairlight.Inputs.{inpCmd.Index:D}.ExternalPortType",
                        $"Fairlight.Inputs.{inpCmd.Index:D}.ActiveConfiguration"
                    };

                    /*
                    if (inpCmd.ActiveConfiguration != inputState.ActiveConfiguration)
                    {
                        inputState.Sources.Clear();
                        changes.Add($"Fairlight.Inputs.{inpCmd.Index:D}.Sources");
                    }
                    */
                    
                    UpdaterUtil.CopyAllProperties(inpCmd, inputState, new[] {"Index"}, new[] {"Sources"});
                    result.SetSuccess(changes);
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

                        UpdaterUtil.CopyAllProperties(srcCmd, srcState,
                            new[] {"Index", "EqualizerEnabled", "EqualizerGain", "MakeUpGain"});
                        result.SetSuccess($"Fairlight.Inputs.{srcCmd.Index:D}.Sources.{srcCmd.SourceId:D}");
                    });
                }
                else if (command is FairlightMixerSourceDeleteCommand delCmd)
                {
                    UpdaterUtil.TryForKey(result, state.Fairlight.Inputs, (long) delCmd.Index, inputState =>
                    {
                        inputState.Sources.RemoveAll(src => src.SourceId == delCmd.SourceId);
                        result.SetSuccess($"Fairlight.Inputs.{delCmd.Index:D}.Sources.{delCmd.SourceId:D}");
                    });
                }
                // TODO
            }
        }
    }
}