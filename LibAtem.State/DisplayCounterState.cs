using LibAtem.Common;
using LibAtem.State.Tolerance;
using System;

namespace LibAtem.State
{
    [Serializable]
    public class DisplayCounterState
    {
        public PropertiesState Properties { get; } = new PropertiesState();

        public HyperDeckTime CurrentTime { get; set; }

        [Serializable]
        public class PropertiesState
        {
            public bool Enabled { get; set; }

            public uint Opacity { get; set; }

            public uint Size { get; set; }

            [Tolerance(0.01)]
            public double PositionX { get; set; }

            [Tolerance(0.01)]
            public double PositionY { get; set; }

            public bool AutoHide { get; set; }

            public HyperDeckTime StartFrom { get; set; }

            public DisplayCounterClockMode ClockMode { get; set; }

            public DisplayCounterClockState ClockState { get; set; }
        }
    }
}