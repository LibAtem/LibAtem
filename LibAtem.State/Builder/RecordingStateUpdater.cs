using LibAtem.Commands;
using LibAtem.Commands.Recording;
using LibAtem.Common;

namespace LibAtem.State.Builder
{
    internal static class RecordingStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is RecordingSettingsGetCommand rmsuCmd)
            {
                if (state.Recording == null) state.Recording = new RecordingState();

                UpdaterUtil.CopyAllProperties(rmsuCmd, state.Recording.Properties);
                result.SetSuccess($"Recording.Properties");
            }
            else if (command is RecordingISOCommand isoCmd)
            {
                if (state.Recording != null)
                {
                    state.Recording.CanISORecordAllInputs = true;
                    state.Recording.ISORecordAllInputs = isoCmd.ISORecordAllInputs;
                    result.SetSuccess($"Recording.ISORecordAllInputs");
                }
            }
            else if (command is RecordingStatusCommand statusCmd)
            {
                if (state.Recording != null)
                {
                    var decoded = statusCmd.RecordingStatus.ParseRecordingStatus();
                    state.Recording.Status.State = decoded.Item1;
                    state.Recording.Status.Error = decoded.Item2;

                    state.Recording.Status.TotalRecordingTimeAvailable = statusCmd.TotalRecordingTimeAvailable;
                    result.SetSuccess($"Recording.Status");
                }
            }
            else if (command is RecordingDiskInfoCommand diskCmd)
            {
                if (state.Recording != null)
                {
                    if (diskCmd.Status == RecordingDiskStatus.Removed)
                    {
                        state.Recording.Disks.Remove(diskCmd.DiskId);
                    }
                    else
                    {
                        if (!state.Recording.Disks.TryGetValue(diskCmd.DiskId,
                            out RecordingState.RecordingDiskState disk))
                        {
                            disk = new RecordingState.RecordingDiskState();
                            state.Recording.Disks.Add(diskCmd.DiskId, disk);
                        }

                        UpdaterUtil.CopyAllProperties(diskCmd, disk); //, new []{"DiskId"});
                        result.SetSuccess($"Recording.Disks.{diskCmd.DiskId:D}");
                    }
                }
            }
            else if (command is RecordingDurationCommand timecodeCmd)
            {
                if (state.Recording != null)
                {
                    state.Recording.Status.Duration = new Timecode
                    {
                        Hour = timecodeCmd.Hour,
                        Minute = timecodeCmd.Minute,
                        Second = timecodeCmd.Second,
                        Frame = timecodeCmd.Frame,
                        DropFrame = timecodeCmd.IsDropFrame,
                    };
                    result.SetSuccess("Recording.Status.Duration");
                }
            }
        }
    }
}