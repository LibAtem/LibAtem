using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.State.Tolerance;

namespace LibAtem.State
{
    [Serializable]
    public class AudioState
    {
        public ProgramOutState ProgramOut { get; } = new ProgramOutState();

        public Dictionary<long, InputState> Inputs { get; set; } = new Dictionary<long, InputState>();
        public IReadOnlyList<MonitorOutputState> MonitorOutputs { get; set; } = new List<MonitorOutputState>();
        public IReadOnlyList<HeadphoneOutputState> HeadphoneOutputs { get; set; } = new List<HeadphoneOutputState>();

        public Dictionary<AudioSource, bool> Tally { get; set; }

        [Serializable]
        public class LevelsState
        {
            [DecibelTolerance(5)]
            public double[] Levels { get; set; } = new double[0];
            [DecibelTolerance(5)]
            public double[] Peaks { get; set; } = new double[0];
        }

        [Serializable]
        public class ProgramOutState
        {
            [DecibelTolerance(5)]
            public double Gain { get; set; }
            [Tolerance(0.01)]
            public double Balance { get; set; }
            public bool FollowFadeToBlack { get; set; }

            public LevelsState Levels { get; set; }
        }
        
        [Serializable]
        public class MonitorOutputState
        {
            public bool Enabled { get; set; }
            [DecibelTolerance(5)]
            public double Gain { get; set; }

            public bool Mute { get; set; }

            public bool Solo { get; set; }
            public AudioSource SoloSource { get; set; }

            public bool Dim { get; set; }
            public double DimLevel { get; set; }
        }

        [Serializable]
        public class HeadphoneOutputState
        {
            [DecibelTolerance(5)]
            public double Gain { get; set; }

            [DecibelTolerance(5)]
            public double ProgramOutGain { get; set; }
            [DecibelTolerance(5)]
            public double SidetoneGain { get; set; }
            [DecibelTolerance(5)]
            public double TalkbackGain { get; set; }
        }

        [Serializable]
        public class InputState
        {
            public bool IsMixedIn { get; set; }

            public PropertiesState Properties { get; } = new PropertiesState();
            public LevelsState Levels { get; set; }

            public AnalogState Analog { get; set; }

            [Serializable]
            public class PropertiesState
            {
                public AudioSourceType SourceType { get; set; }
                public AudioPortType PortType { get; set; }
                public AudioMixOption MixOption { get; set; }
                [DecibelTolerance(5)]
                public double Gain { get; set; }
                [Tolerance(0.01)]
                public double Balance { get; set; }
            }

            [Serializable]
            public class AnalogState
            {
                public bool RcaToXlr { get; set; }
            }
        }
    }
}