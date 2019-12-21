using System;
using System.Collections.Generic;

namespace LibAtem.State
{
    [Serializable]
    public class FairlightAudioState
    {
        public ProgramOutState ProgramOut { get; } = new ProgramOutState();

        public Dictionary<long, InputState> Inputs { get; set; } = new Dictionary<long, InputState>();
        public IReadOnlyList<MonitorOutputState> Monitors { get; set; } = new List<MonitorOutputState>();

        [Serializable]
        public class ProgramOutState
        {
            public double Gain { get; set; }
            public bool FollowFadeToBlack { get; set; }

            public DynamicsState Dynamics { get; } = new DynamicsState();
        }

        [Serializable]
        public class MonitorOutputState
        {
            // TODO
        }

        [Serializable]
        public class InputState
        {
        }

        [Serializable]
        public class DynamicsState
        {
            public double MakeUpGain { get; set; }

            public LimiterState Limiter { get; set; }
            public CompressorState Compressor { get; set; }
        }

        [Serializable]
        public class LimiterState
        {
            public bool LimiterEnabled { get; set; }
            public double Threshold { get; set; }
            public double Attack { get; set; }
            public double Hold{ get; set; }
            public double Release { get; set; }
        }

        [Serializable]
        public class CompressorState
        {
            public bool CompressorEnabled { get; set; }
            public double Threshold { get; set; }
            public double Ratio { get; set; }
            public double Attack { get; set; }
            public double Hold { get; set; }
            public double Release { get; set; }
        }

    }
}