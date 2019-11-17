using LibAtem.Commands;
using LibAtem.Commands.Media;

namespace LibAtem.State.Builder
{
    internal static class MediaPlayerStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is MediaPlayerSourceGetCommand sourceCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MediaPlayers, (int) sourceCmd.Index, mp =>
                {
                    UpdaterUtil.CopyAllProperties(sourceCmd, mp.Source, new []{"Index"});
                    result.SetSuccess($"MediaPlayers.{sourceCmd.Index}.Source");
                });
            }
            else if (command is MediaPlayerClipStatusGetCommand statusCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MediaPlayers, (int) statusCmd.Index, mp =>
                {
                    UpdaterUtil.CopyAllProperties(statusCmd, mp.Status, new []{"Index"});
                    result.SetSuccess($"MediaPlayers.{statusCmd.Index}.Status");
                });
            }
        }
    }
}