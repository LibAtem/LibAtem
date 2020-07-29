using System;

namespace LibAtem.Common
{
    public enum HyperDeckStorageStatus
    {
        Unavailable = 0,
        Ready = 1,
    }

    public enum HyperDeckConnectionStatus
    {
        NotConnected = 0,
        Connecting = 1,
        Connected = 2,
        Incompatible = 3,
    }

    public enum HyperDeckPlayerState {
        Playing = 0,
        Idle = 1,
        Shuttle = 2,
        Recording = 4,
    }

    [Serializable]
    public class HyperDeckTime
    {
        public uint Hour { get; set; }
        public uint Minute { get; set; }
        public uint Second { get; set; }
        public uint Frame { get; set; }
    }
}
