using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Commands.Media;
using LibAtem.Common;
using System.Linq;

namespace LibAtem.State.Builder
{
    internal static class MediaPoolStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is MediaPoolConfigCommand confCmd)
            {
                state.MediaPool.Clips = UpdaterUtil.CreateList(confCmd.ClipCount, i => new MediaPoolState.ClipState());
                state.MediaPool.Stills = UpdaterUtil.CreateList(confCmd.StillCount, i => new MediaPoolState.StillState());
                result.SetSuccess($"MediaPool");
            }
            else if (command is MediaPoolFrameDescriptionCommand frameCmd)
            {
                switch (frameCmd.Bank)
                {
                    case MediaPoolFileType.Still:
                        UpdaterUtil.TryForIndex(result, state.MediaPool.Stills, (int) frameCmd.Index, still =>
                        {
                            UpdaterUtil.CopyAllProperties(frameCmd, still, new[] {"Index", "Bank"});
                            result.SetSuccess($"MediaPlayers.Stills.{frameCmd.Index:D}");
                        });
                        break;
                    case MediaPoolFileType.Clip1:
                    case MediaPoolFileType.Clip2:
                        int bankId = (int) frameCmd.Bank - 1;
                        /* TODO - this may error(?) as the frames arent being created yet..
                        UpdaterUtil.TryForIndex(result, state.MediaPool.Clips, bankId, clip =>
                        {
                            UpdaterUtil.TryForIndex(result, clip.Frames, (int) frameCmd.Index, frame =>
                            {
                                UpdaterUtil.CopyAllProperties(frameCmd, frame, new[] {"Index", "Bank", "Hash"});
                                result.SetSuccess($"MediaPlayers.Clips.{bankId:D}.Frames.{frameCmd.Index:D}");
                            });
                        });
                        */
                        break;
                }
            } else if (command is MediaPoolClipDescriptionCommand clipCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MediaPool.Clips, (int)clipCmd.Index, clip =>
                {
                    clip.IsUsed = clipCmd.IsUsed;
                    clip.Name = clipCmd.Name;
                    clip.Frames = Enumerable.Range(0, (int)clipCmd.FrameCount).Select(i => new MediaPoolState.FrameState()).ToList();

                    result.SetSuccess($"MediaPlayers.Clips.{clipCmd.Index:D}");
                });
            }
        }
    }
}