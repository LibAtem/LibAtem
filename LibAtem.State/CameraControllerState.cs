using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.State.Tolerance;

namespace LibAtem.State
{
    [Serializable]
    public class CameraControlState
    {
        public uint PeriodicFlushInterval { get; set; }

        public Dictionary<long, CameraState> Cameras { get; } = new Dictionary<long, CameraState>();

        [Serializable]
        public class CameraState
        {
            public CameraSettingsState Camera { get; } = new CameraSettingsState();
            public ChipSettingsState Chip { get; } = new ChipSettingsState();
            public LensSettingsState Lens { get; } = new LensSettingsState();

            public bool ColorBars { get; set; }
        }

        [Serializable]
        public class CameraSettingsState
        {
            public CameraDetail Detail { get; set; }
            public bool DetailPeriodicFlushEnabled { get; set; }

            public int Gain { get; set; }
            public bool GainPeriodicFlushEnabled { get; set; }

            public uint PositiveGain { get; set; }
            public bool PositiveGainPeriodicFlushEnabled { get; set; }

            public uint Shutter { get; set; }
            public bool ShutterPeriodicFlushEnabled { get; set; }

            public uint WhiteBalance { get; set; }
            public bool WhiteBalancePeriodicFlushEnabled { get; set; }
        }

        [Serializable]
        public class ChipSettingsState
        {
            public RGBYState Lift { get; } = new RGBYState();
            public RGBYState Gamma { get; } = new RGBYState();
            public RGBYState Gain { get; } = new RGBYState();

            [Tolerance(0.01)]
            public double Contrast { get; set; }
            public bool ContrastPeriodicFlushEnabled { get; set; }

            [Tolerance(0.01)]
            public double Hue { get; set; }
            [Tolerance(0.01)]
            public double Saturation { get; set; }
            public bool HueSaturationPeriodicFlushEnabled { get; set; }

            [Tolerance(0.01)]
            public double LumMix { get; set; }
            public bool LumMixPeriodicFlushEnabled { get; set; }

            [Tolerance(0.01)]
            public double Aperture { get; set; }
            public bool AperturePeriodicFlushEnabled { get; set; }
        }

        [Serializable]
        public class LensSettingsState
        {
            [Tolerance(0.01)]
            public double ZoomSpeed { get; set; }
            public bool ZoomSpeedPeriodicFlushEnabled { get; set; }

            [Tolerance(0.01)]
            public double Focus { get; set; }
            public bool FocusPeriodicFlushEnabled { get; set; }

            [Tolerance(0.01)]
            public double Iris { get; set; }
            public bool IrisPeriodicFlushEnabled { get; set; }
        }

        [Serializable]
        public class RGBYState
        {
            [Tolerance(0.01)]
            public double R { get; set; }
            [Tolerance(0.01)]
            public double G { get; set; }
            [Tolerance(0.01)]
            public double B { get; set; }
            [Tolerance(0.01)]
            public double Y { get; set; }

            public bool PeriodicFlushEnabled { get; set; }
        }

    }
}