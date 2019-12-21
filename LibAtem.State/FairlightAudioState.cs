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
    }
}