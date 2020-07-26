using System;
using LibAtem.Commands;
using LibAtem.Commands.CameraControl;
using LibAtem.State.Util;

namespace LibAtem.State.Builder
{
    internal static class CameraControllerUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command, AtemStateBuilderSettings settings)
        {
            if (command is CCstCommand ccstCmd)
            {
                result.SetSuccess("CameraControl");

            } else if (state.CameraControl != null) { 
                if (command is CameraControlGetCommand camCmd)
                {
                    if (!state.CameraControl.ContainsKey((int)camCmd.Input)) state.CameraControl[(int)camCmd.Input] = new CameraControlState();

                    UpdaterUtil.TryForKey(result, state.CameraControl, (long)camCmd.Input, input =>
                    {
                        try
                        {
                            string[] path = CameraControlUtil.ApplyToState(input, camCmd, settings.IgnoreUnknownCameraControlProperties);
                            if (path.Length > 0) result.SetSuccess(path);
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