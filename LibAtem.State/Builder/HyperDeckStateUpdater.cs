using LibAtem.Commands;
using LibAtem.Commands.Settings.HyperDeck;
using LibAtem.Common;

namespace LibAtem.State.Builder
{
    internal static class HyperDeckStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is HyperDeckSettingsGetCommand hyperdeckCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Hyperdecks, (int)hyperdeckCmd.Id, deck =>
                {
                    UpdaterUtil.CopyAllProperties(hyperdeckCmd, deck.Settings, new[] {"Id", "StorageMediaCount" },
                        new[] {"StorageMedia", "ActiveStorageMedia", "FrameRate", "TimeScale", "IsInterlaced", "IsDropFrameTimecode" });
                    deck.Settings.StorageMedia = UpdaterUtil.UpdateList(deck.Settings.StorageMedia,
                        hyperdeckCmd.StorageMediaCount, i => HyperDeckStorageStatus.Unavailable);

                    result.SetSuccess($"Hyperdecks.{hyperdeckCmd.Id:D}.Settings");
                });
            }
            else if (command is HyperDeckPlayerGetCommand rxcpCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Hyperdecks, (int)rxcpCmd.Id, deck =>
                {
                    UpdaterUtil.CopyAllProperties(rxcpCmd, deck.Player, new[] {"Id"}, new[] {"CurrentClipId"});
                    result.SetSuccess($"Hyperdecks.{rxcpCmd.Id:D}.Player");
                });
            }
            else if (command is HyperDeckSourceGetCommand rxssCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Hyperdecks, (int)rxssCmd.Id, deck =>
                {
                    //UpdaterUtil.CopyAllProperties(rxcpCmd, deck.Player, new[] { "Id" });

                    // TODO properly
                    deck.Settings.ActiveStorageMedia = rxssCmd.ActiveStorageMedia;
                    deck.Player.CurrentClipId = rxssCmd.CurrentClipId;

                    deck.Settings.FrameRate = rxssCmd.FrameRate;
                    deck.Settings.TimeScale = rxssCmd.TimeScale;
                    deck.Settings.IsInterlaced = rxssCmd.IsInterlaced;
                    deck.Settings.IsDropFrameTimecode = rxssCmd.IsDropFrameTimecode;

                    result.SetSuccess($"Hyperdecks.{rxssCmd.Id:D}.Player");
                });
            }
            else if (command is HyperDeckClipCountCommand clipCountCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Hyperdecks, (int)clipCountCmd.Id, deck =>
                {
                    deck.Clips = UpdaterUtil
                        .CreateList(clipCountCmd.ClipCount, o => new HyperdeckState.ClipState());

                    result.SetSuccess($"Hyperdecks.{clipCountCmd.Id:D}.Clips");
                });
            }
            else if (command is HyperDeckClipInfoCommand clipCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Hyperdecks, (int)clipCmd.HyperdeckId, deck =>
                {
                    UpdaterUtil.TryForIndex(result, deck.Clips, (int) clipCmd.ClipId, clip =>
                    {
                        UpdaterUtil.CopyAllProperties(clipCmd, clip, new[] { "ClipId", "HyperdeckId" });
                        result.SetSuccess($"Hyperdecks.{clipCmd.HyperdeckId:D}.Clips.{clipCmd.ClipId:D}");
                    });
                });
            }
        }
    }
}