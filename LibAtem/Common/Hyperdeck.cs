using System;

namespace LibAtem.Common
{
    public enum HyperDeckStorageStatus
    {
        Ready = 0, // TODO
        Unavailable = 1, // TODO
    }

    public enum HyperDeckConnectionStatus
    {
        NotConnected = 0,
        Connecting = 1,
        Connected = 2,
        Incompatible = 3,
    }

    public enum HyperDeckPlayerState {
        Idle = 1,
        Playing = 0,
        Shuttle = 2,
        Recording = 4,
        // Unknown = 6, // TODO
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
