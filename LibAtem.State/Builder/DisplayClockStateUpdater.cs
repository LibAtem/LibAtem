using LibAtem.Commands;
using System.Collections.Generic;

namespace LibAtem.State.Builder
{
    internal static class DisplayClockStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is DisplayClockPropertiesGetCommand propsCmd)
            {
                if (state.DisplayClock == null) state.DisplayClock = new DisplayClockState();

                UpdaterUtil.CopyAllProperties(propsCmd, state.DisplayClock.Properties,
                   new List<string> { },
                   new List<string> { });
                result.SetSuccess("DisplayClock.Properties");
            }
            else if (command is DisplayClockCurrentTimeCommand timeCmd)
            {
                if (state.DisplayClock == null)
                {
                    result.AddError($"Update for unknown DisplayClock");
                }
                else
                {
                    state.DisplayClock.CurrentTime = timeCmd.Time;
                    result.SetSuccess("DisplayClock.CurrentTime");
                }
            }
        }
    }
}