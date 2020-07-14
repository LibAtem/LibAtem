using System;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.CameraControl;
using LibAtem.Commands.Audio;
using LibAtem.Commands.DeviceProfile;
using LibAtem.Common;

namespace LibAtem.State.Builder
{
    internal static class CameraControllerUpdater
    {
        public static void Update(AtemState state, UpdateResultImpl result, ICommand command)
        {
            if (command is CCstCommand ccstCmd)
            {
                state.CameraControl = new CameraControllerState
                {
                    
                };
                result.SetSuccess("CameraControl");
                //result.SetSuccess("Audio.MonitorOutputs");

            } else if (state.CameraControl != null) { 
                if (command is CameraControlGetCommand camCmd)
                {
                    if (!state.CameraControl.Cams.ContainsKey((int)camCmd.Input)) state.CameraControl.Cams[(int)camCmd.Input] = new CameraControllerState.CamState();

                    UpdaterUtil.TryForKey(result, state.CameraControl.Cams, (long)camCmd.Input, input =>
                    {

                        if (camCmd.AdjustmentDomain == AdjustmentDomain.Camera)
                        {
                           
                            if(camCmd.CameraFeature == CameraFeature.Detail)
                            {
                                input.Camera.Detail = camCmd.Detail;
                            }
                            else if (camCmd.CameraFeature == CameraFeature.Gain)
                            {
                                input.Camera.Gain = camCmd.CameraGain;
                            }
                            else if (camCmd.CameraFeature == CameraFeature.PositiveGain)
                            {
                                input.Camera.PositivieGain = camCmd.CameraPositiveGain;
                            }
                            else if (camCmd.CameraFeature == CameraFeature.Shutter)
                            {
                                input.Camera.Shutter = camCmd.Shutter;
                            }
                            else if (camCmd.CameraFeature == CameraFeature.WhiteBalance)
                            {
                                input.Camera.WhiteBalance = camCmd.WhiteBalance;
                            }
                        }
                        else if(camCmd.AdjustmentDomain == AdjustmentDomain.Lens)
                        {

                            if(camCmd.LensFeature == LensFeature.Zoom)
                            {
                                input.Lens.ZoomSpeed = camCmd.ZoomSpeed;
                            }
                            else if (camCmd.LensFeature == LensFeature.Focus)
                            {
                                input.Lens.Focus = camCmd.Focus;
                            }
                            else if (camCmd.LensFeature == LensFeature.Iris)
                            {
                                input.Lens.Iris = camCmd.Iris;
                            }
                        }
                        else if (camCmd.AdjustmentDomain == AdjustmentDomain.Chip)
                        {

                            if (camCmd.ChipFeature == ChipFeature.Lift)
                            {
                                input.Chip.Lift.R = camCmd.R;
                                input.Chip.Lift.G = camCmd.G;
                                input.Chip.Lift.B = camCmd.B;
                                input.Chip.Lift.Y = camCmd.Y;
                            }
                            else if (camCmd.ChipFeature == ChipFeature.Gamma)
                            {
                                input.Chip.Gamma.R = camCmd.R;
                                input.Chip.Gamma.G = camCmd.G;
                                input.Chip.Gamma.B = camCmd.B;
                                input.Chip.Gamma.Y = camCmd.Y;
                            }
                            else if (camCmd.ChipFeature == ChipFeature.Gain)
                            {
                                input.Chip.Gain.R = camCmd.R;
                                input.Chip.Gain.G = camCmd.G;
                                input.Chip.Gain.B = camCmd.B;
                                input.Chip.Gain.Y = camCmd.Y;
                            }
                            else if(camCmd.ChipFeature == ChipFeature.Contrast)
                            {
                                input.Chip.Contrast = camCmd.Contrast;
                            }
                            else if (camCmd.ChipFeature == ChipFeature.HueSaturation)
                            {
                                input.Chip.Hue = camCmd.Hue;
                                input.Chip.Saturation = camCmd.Saturation;
                            }
                            else if (camCmd.ChipFeature == ChipFeature.Lum)
                            {
                                input.Chip.LumMix = camCmd.LumMix;
                            }
                            else if (camCmd.ChipFeature == ChipFeature.Aperture)
                            {
                                input.Chip.Aperture = camCmd.Aperture;
                            }
                        }
                        else if (camCmd.AdjustmentDomain == AdjustmentDomain.ColourBars)
                        {
                            input.ColorBars = camCmd.ColorBars;
                        }

                    });
                }
              
            }
        }
    }
}