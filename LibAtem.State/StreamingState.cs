using System;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class StreamingState
    {
        public StatusState Status { get; } = new StatusState();
        public StatsState Stats { get; } = new StatsState();
        public SettingsState Settings { get; } = new SettingsState();

        public AuthenticationState Authentication { get; } = new AuthenticationState();

        [Serializable]
        public class StatusState
        {
            public Timecode Duration { get; set; }

            public StreamingStatus State { get; set; }
            public StreamingError Error { get; set; }
        }

        [Serializable]
        public class StatsState
        {
            public uint CacheUsed { get; set; }

            public uint EncodingBitrate { get; set; }
        }

        [Serializable]
        public class SettingsState
        {
            public string ServiceName { get; set; }
            public string Url { get; set; }
            public string Key{ get; set; }

            public uint LowVideoBitrate { get; set; }
            public uint HighVideoBitrate { get; set; }

            public uint LowAudioBitrate { get; set; }
            public uint HighAudioBitrate { get; set; }
        }

        [Serializable]
        public class AuthenticationState
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
