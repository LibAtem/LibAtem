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
                    UpdaterUtil.CopyAllProperties(masterCmd, state.Fairlight.ProgramOut,
                        new[] {"EqualizerGain", "EqualizerEnabled", "MakeUpGain"});
                    result.SetSuccess("Fairlight.ProgramOut");
                }
                // TODO
            }
        }
    }
}