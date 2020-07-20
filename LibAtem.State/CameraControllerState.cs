using System;
using LibAtem.Common;

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
            public uint PositivieGain { get; set; }
            public uint Shutter { get; set; }
            public uint WhiteBalance { get; set; }
        }

        [Serializable]
        public class ChipState
        {
            public RGBYState Lift { get; } = new RGBYState();
            public RGBYState Gamma { get; } = new RGBYState();
            public RGBYState Gain { get; } = new RGBYState();

            public uint Contrast { get; set; }
            public int Hue { get; set; }
            public uint Saturation { get; set; }
            public uint LumMix { get; set; }
            public uint Aperture { get; set; }
        }

        [Serializable]
        public class LensState
        {
            public int ZoomSpeed { get; set; }
            public int Focus { get; set; }
            public uint Iris { get; set; }
        }

        [Serializable]
        public class RGBYState
        {
            public int R { get; set; }
            public int G { get; set; }
            public int B { get; set; }
            public int Y { get; set; }
        }

    }
}