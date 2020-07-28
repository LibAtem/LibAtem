using System;
using System.Collections.Generic;
using LibAtem.Commands.Settings.HyperDeck;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class HyperdeckState
    {
        public SettingsState Settings { get; } = new SettingsState();
        public PlayerState Player { get; } = new PlayerState();

        public IReadOnlyList<ClipState> Clips { get; set; } = new List<ClipState>();

        [Serializable]
        public class ClipState
        {
            public string Name { get; set; }
            public Time Duration { get; set; }

            public Time TimelineStart { get; set; }
            public Time TimelineEnd{ get; set; }

        }

        [Serializable]
        public class Time
        {
            public Time()
            {
            }

            public Time(uint hour, uint minute, uint second, uint frame)
            {
                Hour = hour;
                Minute = minute;
                Second = second;
                Frame = frame;
            }

            public uint Hour { get;  }
            public uint Minute { get; }
            public uint Second { get; }
            public uint Frame { get;}
        }

        [Serializable]
        public class PlayerState
        {
            public HyperDeckPlayerState State { get; set; }
            public bool Loop { get; set; }
            public bool SingleClip { get; set; }
            public uint PlaybackSpeed { get; set; }
        }

        [Serializable]
        public class SettingsState
        {
            public string NetworkAddress { get; set; }
            public VideoSource Input { get; set; }
            public bool AutoRoll { get; set; }
            public uint AutoRollFrameDelay { get; set; }

            public HyperDeckConnectionStatus Status { get; set; }
            public bool IsRemoteEnabled { get; set; }

            public IReadOnlyList<HyperDeckStorageStatus> StorageMedia { get; set; } = new List<HyperDeckStorageStatus>();
            public int ActiveStorageMedia { get; set; }
        }
    }
}