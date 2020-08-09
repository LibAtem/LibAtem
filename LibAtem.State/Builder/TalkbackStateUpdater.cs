using LibAtem.Commands;
using LibAtem.Commands.Audio;
using LibAtem.Commands.Talkback;

namespace LibAtem.State.Builder
{
    internal static class TalkbackStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is TalkbackMixerPropertiesGetCommand talkbackCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Settings.Talkback, (int)talkbackCmd.Channel, channel =>
                {
                    channel.MuteSDI = talkbackCmd.MuteSDI;
                    result.SetSuccess($"Settings.Talkback.{talkbackCmd.Channel:D}");
                });
            }
            else if (command is TalkbackMixerInputPropertiesGetCommand inputCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Settings.Talkback, (int)inputCmd.Channel, channel =>
                {
                    if (!channel.Inputs.TryGetValue(inputCmd.Index, out SettingsState.TalkbackInputState input))
                    {
                        input = channel.Inputs[inputCmd.Index] = new SettingsState.TalkbackInputState();
                    }

                    UpdaterUtil.CopyAllProperties(inputCmd, input, new[] {"Channel", "Index"});

                    result.SetSuccess($"Settings.Talkback.{inputCmd.Channel:D}.Inputs.{inputCmd.Index:D}");
                });
            }
        }
    }
}