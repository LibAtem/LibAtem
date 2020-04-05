using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.Media;

namespace LibAtem.State.Builder
{
    internal static class MediaPlayerStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command, AtemStateBuilderSettings updateSettings)
        {
            if (command is MediaPlayerSourceGetCommand sourceCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MediaPlayers, (int) sourceCmd.Index, mp =>
                {
                    UpdaterUtil.CopyAllProperties(sourceCmd, mp.Source, new []{"Index"});
                    result.SetSuccess($"MediaPlayers.{sourceCmd.Index:D}.Source");
                });
            }
            else if (command is MediaPlayerClipStatusGetCommand statusCmd)
            {
                if (state.MediaPool.Clips.Count > 0)
                {
                    UpdaterUtil.TryForIndex(result, state.MediaPlayers, (int) statusCmd.Index, mp =>
                    {
                        if (mp.ClipStatus == null) mp.ClipStatus = new MediaPlayerState.ClipStatusState();

                        var skipProps = new List<string> { "Index" };
                        var ignoreDestProps = new List<string> { "Index" };
                        if (updateSettings != null && !updateSettings.TrackMediaClipFrames)
                        {
                            skipProps.Add("AtBeginning");
                            skipProps.Add("ClipFrame");
                            ignoreDestProps.Add("AtBeginning");
                            ignoreDestProps.Add("ClipFrame");
                        }

                        UpdaterUtil.CopyAllProperties(statusCmd, mp.ClipStatus, skipProps.ToArray(), ignoreDestProps.ToArray());
                        result.SetSuccess($"MediaPlayers.{statusCmd.Index:D}.ClipStatus");
                    });
                }
            }
        }
    }
}