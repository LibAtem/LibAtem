using System;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class DownstreamKeyerState
    {
        public SourcesState Sources { get; } = new SourcesState();
        public PropertiesState Properties { get; } = new PropertiesState();
        public StateState State { get; } = new StateState();
    }

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
        public double Clip { get; set; }
        public double Gain { get; set; }
        public bool Invert { get; set; }

        public bool MaskEnabled { get; set; }
        public double MaskTop { get; set; }
        public double MaskBottom { get; set; }
        public double MaskLeft { get; set; }
        public double MaskRight { get; set; }
    }

    [Serializable]
    public class StateState
    {
        public bool OnAir { get; set; }
        public bool InTransition { get; set; }
        public bool IsAuto { get; set; }
        public uint RemainingFrames { get; set; }
    }
}