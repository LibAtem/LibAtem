using LibAtem.Commands;
using LibAtem.Common;
using System;
using System.Collections.Generic;

namespace LibAtem.State.Builder
{
    internal static class DisplayCounterStateUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is DisplayCounterPropertiesGetCommand propsCmd)
            {
                if (state.DisplayCounter == null) state.DisplayCounter = new DisplayCounterState();

                UpdaterUtil.CopyAllProperties(propsCmd, state.DisplayCounter.Properties,
                   new List<string> { },
                   new List<string> { });
                result.SetSuccess("DisplayCounter.Properties");
            }
            else if (command is DisplayCounterCurrentTimeCommand timeCmd)
            {
                if (state.DisplayCounter == null)
                {
                    result.AddError($"Update for unknown DisplayCounter");
                }
                else
                {
                    state.DisplayCounter.CurrentTime = timeCmd.Time;
                    result.SetSuccess("DisplayCounter.CurrentTime");
                }
            }
        }
    }
}