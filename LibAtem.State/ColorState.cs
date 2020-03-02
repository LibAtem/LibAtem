using LibAtem.State.Tolerance;
using System;

namespace LibAtem.State
{
    [Serializable]
    public class ColorState
    {
        [Tolerance(0.01)]
        public double Hue { get; set; }
        [Tolerance(0.01)]
        public double Saturation { get; set; }
        [Tolerance(0.01)]
        public double Luma { get; set; }
    }
}