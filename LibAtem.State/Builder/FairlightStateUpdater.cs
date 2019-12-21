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
                        i => new FairlightAudioState.MonitorOutputState())
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
                        new[] {"EqualizerGain", "EqualizerEnabled", "MakeUpGain"}, new []{"Dynamics"});

                    pgmState.Dynamics.MakeUpGain = masterCmd.MakeUpGain;

                    result.SetSuccess(new[]
                    {
                        "Fairlight.ProgramOut",
                        "Fairlight.ProgramOut.Dynamics.MakeUpGain"
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
                // TODO
            }
        }
    }
}