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
                    UpdaterUtil.CopyAllProperties(hyperdeckCmd, deck.Settings, new[] {"Id", "StorageMediaCount"},
                        new[] {"StorageMedia"});
                    deck.Settings.StorageMedia = UpdaterUtil.UpdateList(deck.Settings.StorageMedia,
                        hyperdeckCmd.StorageMediaCount, i => HyperDeckStorageStatus.Unavailable);

                    result.SetSuccess($"Hyperdecks.{hyperdeckCmd.Id:D}.Settings");
                });
            }
            else if (command is HyperDeckPlayerGetCommand playerCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Hyperdecks, (int)playerCmd.Id, deck =>
                {
                    UpdaterUtil.CopyAllProperties(playerCmd, deck.Player, new[] {"Id"});
                    result.SetSuccess($"Hyperdecks.{playerCmd.Id:D}.Player");
                });
            }
            else if (command is HyperDeckStorageGetCommand storageCmd)
            {
                UpdaterUtil.TryForIndex(result, state.Hyperdecks, (int)storageCmd.Id, deck =>
                {
                    UpdaterUtil.CopyAllProperties(storageCmd, deck.Storage, new[] { "Id" });
                    result.SetSuccess($"Hyperdecks.{storageCmd.Id:D}.Storage");
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