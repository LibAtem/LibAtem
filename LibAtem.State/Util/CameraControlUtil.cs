using System;
using LibAtem.Commands.CameraControl;
using LibAtem.Common;

namespace LibAtem.State.Util
{
    public static class CameraControlUtil
    {
        private static void EnsureLength(CameraControlGetCommand cmd, int expectedLength)
        {
            bool fail = false;

            if (cmd.FloatData != null && cmd.IntData != null)
                fail = true;
            else if (cmd.FloatData == null && cmd.IntData == null)
                fail = true;

            if (expectedLength != 0)
            {
                if (cmd.FloatData != null && cmd.FloatData.Length != expectedLength)
                    fail = true;
                if (cmd.IntData != null && cmd.IntData.Length != expectedLength)
                    fail = true;
            }

            if (fail)
                throw new Exception($"Not enough values (target: {expectedLength})");
        }

        public static string[] ApplyToState(CameraControlState input, CameraControlGetCommand cmd)
        {
            AdjustmentDomain category = (AdjustmentDomain) cmd.Category;
            if (category == AdjustmentDomain.Camera)
            {
                switch ((CameraFeature)cmd.Parameter)
                {
                    case CameraFeature.Detail:
                        EnsureLength(cmd, 1);
                        input.Camera.Detail = (CameraDetail) cmd.IntData[0];
                        return new[] {"Camera.Detail"};
                    case CameraFeature.Gain:
                        EnsureLength(cmd, 1);
                        input.Camera.Gain = cmd.IntData[0];
                        return new[] { "Camera.Gain"};
                    case CameraFeature.PositiveGain:
                        EnsureLength(cmd, 1);
                        input.Camera.PositiveGain = (uint) cmd.IntData[0];
                        return new[] { "Camera.PositiveGain"};
                    case CameraFeature.Shutter:
                        EnsureLength(cmd, 1);
                        input.Camera.Shutter = (uint) cmd.IntData[0];
                        return new[] { "Camera.Shutter"};
                    case CameraFeature.WhiteBalance:
                        EnsureLength(cmd, 1);
                        input.Camera.WhiteBalance = (uint) cmd.IntData[0];
                        return new[] { "Camera.WhiteBalance"};
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (category == AdjustmentDomain.Lens)
            {
                switch ((LensFeature)cmd.Parameter)
                {
                    case LensFeature.Zoom:
                        EnsureLength(cmd, 1);
                        input.Lens.ZoomSpeed = cmd.FloatData[0];
                        return new[] {"Lens.ZoomSpeed"};
                    case LensFeature.Focus:
                        EnsureLength(cmd, 1);
                        input.Lens.Focus = cmd.FloatData[0];
                        return new[] {"Lens.Focus"};
                    case LensFeature.Iris:
                        EnsureLength(cmd, 1);
                        input.Lens.Iris = cmd.FloatData[0];
                        return new[] {"Lens.Iris"};
                    case LensFeature.AutoFocus:
                        EnsureLength(cmd, 0);
                        return new[] {"Lens.AutoFocus"};
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (category == AdjustmentDomain.Chip)
            {
                switch ((ChipFeature)cmd.Parameter)
                {
                    case ChipFeature.Lift:
                        EnsureLength(cmd, 4);
                        input.Chip.Lift.R = cmd.FloatData[0];
                        input.Chip.Lift.G = cmd.FloatData[1];
                        input.Chip.Lift.B = cmd.FloatData[2];
                        input.Chip.Lift.Y = cmd.FloatData[3];
                        return new[] {"Chip.Lift"};
                    case ChipFeature.Gamma:
                        EnsureLength(cmd, 4);
                        input.Chip.Gamma.R = cmd.FloatData[0];
                        input.Chip.Gamma.G = cmd.FloatData[1];
                        input.Chip.Gamma.B = cmd.FloatData[2];
                        input.Chip.Gamma.Y = cmd.FloatData[3];
                        return new[] {"Chip.Gamma"};
                    case ChipFeature.Gain:
                        EnsureLength(cmd, 4);
                        input.Chip.Gain.R = cmd.FloatData[0];
                        input.Chip.Gain.G = cmd.FloatData[1];
                        input.Chip.Gain.B = cmd.FloatData[2];
                        input.Chip.Gain.Y = cmd.FloatData[3];
                        return new[] {"Chip.Gain"};
                    case ChipFeature.Contrast:
                        EnsureLength(cmd, 2);
                        // TODO - byte 0
                        input.Chip.Contrast = cmd.FloatData[1];
                        return new[] {"Chip.Contrast"};
                    case ChipFeature.HueSaturation:
                        EnsureLength(cmd, 2);
                        input.Chip.Hue = cmd.FloatData[0];
                        input.Chip.Saturation = cmd.FloatData[1];
                        return new[] {"Chip.Hue", "Chip.Saturation"};
                    case ChipFeature.Lum:
                        EnsureLength(cmd, 1);
                        input.Chip.LumMix = cmd.FloatData[0];
                        return new[] { "Chip.LumMix" };
                    case ChipFeature.Aperture:
                        EnsureLength(cmd, 4);
                        // TODO - byte 1, 2, 3
                        input.Chip.Aperture = cmd.FloatData[0];
                        return new[] { "Chip.Aperture" };
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (category == AdjustmentDomain.ColourBars)
            {
                switch (cmd.Parameter)
                {
                    case 4:
                    {
                        input.ColorBars = cmd.IntData[0] == 1;
                        return new[] { "ColorBars" };
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                //throw new ArgumentOutOfRangeException();
                // TODO - not everything is parsed yet
                return new string[0];
            }
        }
    }
}
