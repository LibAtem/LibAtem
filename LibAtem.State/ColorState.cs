using System;

namespace LibAtem.State
{
    [Serializable]
    public class ColorState
    {
        public double Hue { get; set; }
        public double Saturation { get; set; }
        public double Luma { get; set; }
    }
}