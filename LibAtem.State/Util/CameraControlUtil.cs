using System;
using LibAtem.Commands.CameraControl;
using LibAtem.Common;

namespace LibAtem.State.Util
{
    public static class CameraControlUtil
    {
        private static void EnsureDataIsValid(CameraControlGetCommand cmd, CameraControlDataType expectedType,
            int expectedLength)
        {
            if (cmd.Type != expectedType)
                throw new Exception($"Incorrect type (target: {expectedType}, got: {cmd.Type})");

            bool fail = false;

            uint notNull = 0;
            if (cmd.FloatData != null) notNull++;
            if (cmd.IntData != null) notNull++;
            if (cmd.BoolData != null) notNull++;
            if (cmd.LongData != null) notNull++;
            if (cmd.StringData != null) notNull++;

            if (notNull != 1)
                fail = true;

            if (expectedLength != 0)
            {
                if (cmd.FloatData != null && cmd.FloatData.Length != expectedLength)
                    fail = true;
                if (cmd.IntData != null && cmd.IntData.Length != expectedLength)
                    fail = true;
                if (cmd.BoolData != null && cmd.BoolData.Length != expectedLength)
                    fail = true;
                if (cmd.LongData != null && cmd.LongData.Length != expectedLength)
                    fail = true;
                if (cmd.StringData != null && cmd.StringData.Length != expectedLength)
                    fail = true;
            }

            if (fail)
                throw new Exception($"Not enough values (target: {expectedLength})");
        }

        public static string[] ApplyToState(CameraControlState.CameraState input, CameraControlGetCommand cmd, bool ignoreUnknown)
        {
            AdjustmentDomain category = (AdjustmentDomain) cmd.Category;
            if (category == AdjustmentDomain.Camera)
            {
                switch ((CameraFeature)cmd.Parameter)
                {
                    case CameraFeature.Detail:
                        EnsureDataIsValid(cmd, CameraControlDataType.SInt8, 1);
                        input.Camera.Detail = (CameraDetail) cmd.IntData[0];
                        input.Camera.DetailPeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case CameraFeature.Gain:
                        EnsureDataIsValid(cmd, CameraControlDataType.SInt8, 1);
                        input.Camera.Gain = cmd.IntData[0];
                        input.Camera.GainPeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case CameraFeature.PositiveGain:
                        EnsureDataIsValid(cmd, CameraControlDataType.SInt8, 1);
                        input.Camera.PositiveGain = (uint) cmd.IntData[0];
                        input.Camera.PositiveGainPeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case CameraFeature.Shutter:
                        EnsureDataIsValid(cmd, CameraControlDataType.SInt32, 1);
                        input.Camera.Shutter = (uint) cmd.IntData[0];
                        input.Camera.ShutterPeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case CameraFeature.WhiteBalance:
                        EnsureDataIsValid(cmd, CameraControlDataType.SInt16, 1);
                        input.Camera.WhiteBalance = (uint) cmd.IntData[0];
                        input.Camera.WhiteBalancePeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    default:
                        if (ignoreUnknown) return Array.Empty<string>();
                        throw new ArgumentOutOfRangeException();
                }
                return new[] { "Camera" };
            }
            else if (category == AdjustmentDomain.Lens)
            {
                switch ((LensFeature)cmd.Parameter)
                {
                    case LensFeature.Zoom:
                        EnsureDataIsValid(cmd, CameraControlDataType.Float, 1);
                        input.Lens.ZoomSpeed = cmd.FloatData[0];
                        input.Lens.ZoomSpeedPeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case LensFeature.Focus:
                        EnsureDataIsValid(cmd, CameraControlDataType.Float, 1);
                        input.Lens.Focus = cmd.FloatData[0];
                        input.Lens.FocusPeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case LensFeature.Iris:
                        EnsureDataIsValid(cmd, CameraControlDataType.Float, 1);
                        input.Lens.Iris = cmd.FloatData[0];
                        input.Lens.IrisPeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case LensFeature.AutoFocus:
                        EnsureDataIsValid(cmd, CameraControlDataType.Bool, 0);
                        break;
                    default:
                        if (ignoreUnknown) return Array.Empty<string>();
                        throw new ArgumentOutOfRangeException();
                }
                return new[] { "Lens" };
            }
            else if (category == AdjustmentDomain.Chip)
            {
                switch ((ChipFeature)cmd.Parameter)
                {
                    case ChipFeature.Lift:
                        EnsureDataIsValid(cmd, CameraControlDataType.Float, 4);
                        input.Chip.Lift.R = cmd.FloatData[0];
                        input.Chip.Lift.G = cmd.FloatData[1];
                        input.Chip.Lift.B = cmd.FloatData[2];
                        input.Chip.Lift.Y = cmd.FloatData[3];
                        input.Chip.Lift.PeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case ChipFeature.Gamma:
                        EnsureDataIsValid(cmd, CameraControlDataType.Float, 4);
                        input.Chip.Gamma.R = cmd.FloatData[0];
                        input.Chip.Gamma.G = cmd.FloatData[1];
                        input.Chip.Gamma.B = cmd.FloatData[2];
                        input.Chip.Gamma.Y = cmd.FloatData[3];
                        input.Chip.Gamma.PeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case ChipFeature.Gain:
                        EnsureDataIsValid(cmd, CameraControlDataType.Float, 4);
                        input.Chip.Gain.R = cmd.FloatData[0];
                        input.Chip.Gain.G = cmd.FloatData[1];
                        input.Chip.Gain.B = cmd.FloatData[2];
                        input.Chip.Gain.Y = cmd.FloatData[3];
                        input.Chip.Gain.PeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case ChipFeature.Contrast:
                        EnsureDataIsValid(cmd, CameraControlDataType.Float, 2);
                        // TODO - byte 0
                        input.Chip.Contrast = cmd.FloatData[1];
                        input.Chip.ContrastPeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case ChipFeature.HueSaturation:
                        EnsureDataIsValid(cmd, CameraControlDataType.Float, 2);
                        input.Chip.Hue = cmd.FloatData[0];
                        input.Chip.Saturation = cmd.FloatData[1];
                        input.Chip.HueSaturationPeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case ChipFeature.Lum:
                        EnsureDataIsValid(cmd, CameraControlDataType.Float, 1);
                        input.Chip.LumMix = cmd.FloatData[0];
                        input.Chip.LumMixPeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    case ChipFeature.Aperture:
                        EnsureDataIsValid(cmd, CameraControlDataType.Float, 4);
                        // TODO - byte 1, 2, 3
                        input.Chip.Aperture = cmd.FloatData[0];
                        input.Chip.AperturePeriodicFlushEnabled = cmd.PeriodicFlushEnabled;
                        break;
                    default:
                        if (ignoreUnknown) return Array.Empty<string>();
                        throw new ArgumentOutOfRangeException();
                }
                return new[] { "Chip" };
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
                        if (ignoreUnknown) return Array.Empty<string>();
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                if (ignoreUnknown) return Array.Empty<string>();
                //throw new ArgumentOutOfRangeException();
                // TODO - not everything is parsed yet
                return Array.Empty<string>();
            }
        }
    }
}
