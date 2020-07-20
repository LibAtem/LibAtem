using System;
using System.Collections.Generic;
using System.Text;
using LibAtem.Commands.Streaming;

namespace LibAtem.State
{
    [Serializable]
    public class StreamingState
    {
        public StatusState Status { get; } = new StatusState();
        public SettingsState Settings { get; } = new SettingsState();

        [Serializable]
        public class StatusState
        {
            public bool IsStreaming { get; set; }

            public double CacheUsed { get; set; }

            public uint EncodingBitrate { get; set; }

            public Timecode Duration { get; set; }

            public StreamingStatus State { get; set; }
            public int Error { get; set; }

        }

        [Serializable]
        public class SettingsState
        {
            public string ServiceName { get; set; }
            public string Url { get; set; }
            public string Key{ get; set; }

            public uint LowBitrate { get; set; }
            public uint HighBitrate { get; set; }
        }
    }
}
