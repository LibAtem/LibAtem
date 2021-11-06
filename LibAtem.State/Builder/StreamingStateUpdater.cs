using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.Streaming;
using LibAtem.Common;

namespace LibAtem.State.Builder
{
    internal static class StreamingStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is StreamingServiceGetCommand srsuCmd)
            {
                if (state.Streaming == null) state.Streaming = new StreamingState();

                state.Streaming.Settings.LowVideoBitrate = srsuCmd.Bitrates[0];
                state.Streaming.Settings.HighVideoBitrate = srsuCmd.Bitrates[1];

                UpdaterUtil.CopyAllProperties(srsuCmd, state.Streaming.Settings, 
                    new List<string> {"Bitrates"},
                    new List<string> {"LowVideoBitrate", "HighVideoBitrate", "LowAudioBitrate", "HighAudioBitrate"});
                result.SetSuccess("Streaming.Settings");
            }
            else if (command is StreamingAudioBitratesCommand audioCmd)
            {
                state.Streaming.Settings.LowAudioBitrate = audioCmd.Bitrates[0];
                state.Streaming.Settings.HighAudioBitrate = audioCmd.Bitrates[1];
                result.SetSuccess("Streaming.Settings");
            }
            else if (command is StreamingDurationCommand timecodeCmd)
            {
                if (state.Streaming != null)
                {
                    state.Streaming.Status.Duration = new Timecode
                    {
                        Hour = timecodeCmd.Hour,
                        Minute = timecodeCmd.Minute,
                        Second = timecodeCmd.Second,
                        Frame = timecodeCmd.Frame,
                        DropFrame = timecodeCmd.IsDropFrame,
                    };
                    result.SetSuccess("Streaming.Status.Duration");
                }
            }
            else if (command is StreamingStatusGetCommand stateCmd)
            {
                if (state.Streaming != null)
                {
                    state.Streaming.Status.State = stateCmd.Status;
                    state.Streaming.Status.Error = stateCmd.Error;

                    result.SetSuccess("Streaming.Status.State");
                }
            }
            else if (command is StreamingAuthenticationCommand authCmd)
            {
                if (state.Streaming != null)
                {
                    UpdaterUtil.CopyAllProperties(authCmd, state.Streaming.Authentication);
                    result.SetSuccess("Streaming.Authentication");
                }
            }
            else if (command is StreamingStatsCommand srssCmd)
            {
                if (state.Streaming != null)
                {
                    state.Streaming.Stats.EncodingBitrate = srssCmd.EncodingBitrate;
                    state.Streaming.Stats.CacheUsed = srssCmd.CacheUsed;
                    result.SetSuccess("Streaming.Stats");
                }
            }
            else if (command is StreamingLatencyCommand slCmd)
            {
                if (state.Streaming != null)
                {
                    state.Streaming.IsLowLatency = slCmd.LowLatency;
                    result.SetSuccess("Streaming.IsLowLatency");
                }
            }
        }
    }
}