using System;
using LibAtem.Common;
using LibAtem.State.Tolerance;

namespace LibAtem.State
{
    [Serializable]
    public class CameraControlState
    {
        public CameraSate Camera { get; } = new CameraSate();
        public ChipState Chip { get; } = new ChipState();
        public LensState Lens { get; } = new LensState();

        public bool ColorBars { get; set; }

        [Serializable]
        public class CameraSate
        {
            public CameraDetail Detail { get; set; }
            public int Gain { get; set; }
            public uint PositiveGain { get; set; }
            public uint Shutter { get; set; }
            public uint WhiteBalance { get; set; }
        }

        [Serializable]
        public class ChipState
        {
            public RGBYState Lift { get; } = new RGBYState();
            public RGBYState Gamma { get; } = new RGBYState();
            public RGBYState Gain { get; } = new RGBYState();

            [Tolerance(0.01)]
            public double Contrast { get; set; }
            [Tolerance(0.01)]
            public double Hue { get; set; }
            [Tolerance(0.01)]
            public double Saturation { get; set; }
            [Tolerance(0.01)]
            public double LumMix { get; set; }
            [Tolerance(0.01)]
            public double Aperture { get; set; }
        }

        [Serializable]
        public class LensState
        {
            [Tolerance(0.01)]
            public double ZoomSpeed { get; set; }
            [Tolerance(0.01)]
            public double Focus { get; set; }
            [Tolerance(0.01)]
            public double Iris { get; set; }
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
        }

    }
}