using System;
using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class AudioState
    {
        public ProgramOutState ProgramOut { get; } = new ProgramOutState();

        public TalkbackState Talkback { get; } = new TalkbackState();

        public Dictionary<long, InputState> Inputs { get; set; } = new Dictionary<long, InputState>();
        public IReadOnlyList<MonitorOutputState> Monitors { get; set; } = new List<MonitorOutputState>();

        [Serializable]
        public class ProgramOutState
        {
            public double Gain { get; set; }
            public double Balance { get; set; }
            public bool FollowFadeToBlack { get; set; }

            public double LevelLeft { get; set; } = double.NegativeInfinity;
            public double LevelRight { get; set; } = double.NegativeInfinity;
            public double PeakLeft { get; set; } = double.NegativeInfinity;
            public double PeakRight { get; set; } = double.NegativeInfinity;
        }

        [Serializable]
        public class TalkbackState
        {
            public bool MuteSDI { get; set; }
            public Dictionary<long, bool> Inputs { get; set; } = new Dictionary<long, bool>();
        }
        
        [Serializable]
        public class MonitorOutputState
        {
            public bool Enabled { get; set; }
            public double Gain { get; set; }

            public bool Mute { get; set; }

            public bool Solo { get; set; }
            public AudioSource SoloSource { get; set; }

            public bool Dim { get; set; }
        }
        
        [Serializable]
        public class InputState
        {
            public ExternalPortTypeFlags ExternalPortType { get; set; }
            public AudioMixOption MixOption { get; set; }
            public double Gain { get; set; }
            public double Balance { get; set; }
            public bool IsMixedIn { get; set; }

            public double LevelLeft { get; set; } = double.NegativeInfinity;
            public double LevelRight { get; set; } = double.NegativeInfinity;
            public double PeakLeft { get; set; } = double.NegativeInfinity;
            public double PeakRight { get; set; } = double.NegativeInfinity;
        }
    }
}