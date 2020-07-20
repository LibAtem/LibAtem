using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.Streaming;

namespace LibAtem.State.Builder
{
    internal static class StreamingStateBuilder
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is StreamingServiceGetCommand srsuCmd)
            {
                if (state.Streaming == null) state.Streaming = new StreamingState();

                UpdaterUtil.CopyAllProperties(srsuCmd, state.Streaming.Settings, 
                    new List<string> {"Bitrates"},
                    new List<string> {"LowBitrate", "HighBitrate"});
            result.SetSuccess("Streaming.Settings");
            }
            else if (command is StreamingTimecodeCommand timecodeCmd)
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
            else if (command is StreamingStateCommand stateCmd)
            {
                if (state.Streaming != null)
                {
                    state.Streaming.Status.State = stateCmd.StreamingStatus;

                    result.SetSuccess("Streaming.Status.State");
                }
            }
        }
    }
}