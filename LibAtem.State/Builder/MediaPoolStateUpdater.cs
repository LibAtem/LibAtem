using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Commands.Media;
using LibAtem.Common;
using System.Linq;
using LibAtem.Util;

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
                            result.SetSuccess($"MediaPool.Stills.{frameCmd.Index:D}");
                        });
                        break;
                    case MediaPoolFileType.Clip1:
                    case MediaPoolFileType.Clip2:
                    case MediaPoolFileType.Clip3:
                    case MediaPoolFileType.Clip4:
                        int bankId = (int) frameCmd.Bank - 1;
                        UpdaterUtil.TryForIndex(result, state.MediaPool.Clips, bankId, clip =>
                        {
                            UpdaterUtil.TryForIndex(result, clip.Frames, (int) frameCmd.Index, frame =>
                            {
                                UpdaterUtil.CopyAllProperties(frameCmd, frame, new[] {"Index", "Bank", "Filename" });
                                result.SetSuccess($"MediaPool.Clips.{bankId:D}.Frames.{frameCmd.Index:D}");
                            });
                        });
                        break;
                }
            }
            else if (command is MediaPoolAudioDescriptionCommand audioCmd)
            {
                uint index = audioCmd.Index - 1;
                UpdaterUtil.TryForIndex(result, state.MediaPool.Clips, (int)index, clip =>
                {
                    UpdaterUtil.CopyAllProperties(audioCmd, clip.Audio, new[] {"Index"});
                    result.SetSuccess($"MediaPool.Clips.{index:D}.Audio");
                });
            }
            else if (command is MediaPoolClipDescriptionCommand clipCmd)
            {
                UpdaterUtil.TryForIndex(result, state.MediaPool.Clips, (int)clipCmd.Index, clip =>
                {
                    clip.IsUsed = clipCmd.IsUsed;
                    clip.Name = clipCmd.Name;
                    clip.FrameCount = clipCmd.FrameCount;

                    result.SetSuccess($"MediaPool.Clips.{clipCmd.Index:D}");
                });
            } else if (command is MediaPoolSettingsGetCommand settingsCmd)
            {
                state.MediaPool.Clips.ForEach((i, clip) =>
                {
                    clip.MaxFrames = settingsCmd.MaxFrames[i];
                    clip.Frames = UpdaterUtil.UpdateList(clip.Frames, settingsCmd.MaxFrames[i],
                        o => new MediaPoolState.FrameState());
                });
                state.MediaPool.UnassignedFrames = settingsCmd.UnassignedFrames;
                result.SetSuccess(new[] {$"MediaPool.Clips", $"MediaPool.UnassignedFrames"});
            }
        }
    }
}