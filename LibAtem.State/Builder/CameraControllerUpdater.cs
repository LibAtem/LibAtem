using System;
using System.Linq;
using LibAtem.Commands;
using LibAtem.Commands.CameraControl;
using LibAtem.Common;
using LibAtem.State.Util;

namespace LibAtem.State.Builder
{
    internal static class CameraControllerUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command, AtemStateBuilderSettings settings)
        {
            if (command is CameraControlSettingsGetCommand ccstCmd)
            {
                state.CameraControl.PeriodicFlushInterval = ccstCmd.Interval;
                result.SetSuccess("CameraControl.PeriodicFlushInterval");

            } else if (state.CameraControl != null) { 
                if (command is CameraControlGetCommand camCmd)
                {
                    if (camCmd.Input != VideoSource.Black)
                    {
                        if (!state.CameraControl.Cameras.ContainsKey((int) camCmd.Input))
                            state.CameraControl.Cameras[(int) camCmd.Input] = new CameraControlState.CameraState();

                        UpdaterUtil.TryForKey(result, state.CameraControl.Cameras, (long) camCmd.Input, input =>
                        {
                            try
                            {
                                string[] path = CameraControlUtil.ApplyToState(input, camCmd,
                                    settings.IgnoreUnknownCameraControlProperties);
                                if (path.Length > 0)
                                    result.SetSuccess(path.Select(p => $"CameraControl.Cameras.{camCmd.Input:D}.p"));
                            }
                            catch (Exception e)
                            {
                                result.AddError(e.ToString());
                            }
                        });
                    }
                }
            }
        }
    }
}