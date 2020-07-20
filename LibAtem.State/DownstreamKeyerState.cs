using System;
using LibAtem.Common;
using LibAtem.State.Tolerance;

namespace LibAtem.State
{
    [Serializable]
    public class DownstreamKeyerState
    {
        public SourcesState Sources { get; } = new SourcesState();
        public PropertiesState Properties { get; } = new PropertiesState();
        public StateState State { get; } = new StateState();

        [Serializable]
        public class SourcesState
        {
            public VideoSource FillSource { get; set; }
            public VideoSource CutSource { get; set; }
        }

        [Serializable]
        public class PropertiesState
        {
            public bool Tie { get; set; }
            public uint Rate { get; set; }

            public bool PreMultipliedKey { get; set; }
            [Tolerance(0.01)]
            public double Clip { get; set; }
            [Tolerance(0.01)]
            public double Gain { get; set; }
            public bool Invert { get; set; }

            public bool MaskEnabled { get; set; }
            [Tolerance(0.01)]
            public double MaskTop { get; set; }
            [Tolerance(0.01)]
            public double MaskBottom { get; set; }
            [Tolerance(0.01)]
            public double MaskLeft { get; set; }
            [Tolerance(0.01)]
            public double MaskRight { get; set; }
        }

        [Serializable]
        public class StateState
        {
            public bool OnAir { get; set; }
            public bool InTransition { get; set; }
            public bool IsAuto { get; set; }
            public bool IsTowardsOnAir { get; set; }
            public uint RemainingFrames { get; set; }
        }
    }
}