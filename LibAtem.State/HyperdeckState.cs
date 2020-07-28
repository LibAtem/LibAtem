using System;
using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class HyperdeckState
    {
        public StorageState Storage { get; } = new StorageState();
        public SettingsState Settings { get; } = new SettingsState();
        public PlayerState Player { get; } = new PlayerState();

        public IReadOnlyList<ClipState> Clips { get; set; } = new List<ClipState>();

        [Serializable]
        public class ClipState
        {
            public string Name { get; set; }
            public HyperDeckTime Duration { get; set; }

            public HyperDeckTime TimelineStart { get; set; }
            public HyperDeckTime TimelineEnd { get; set; }

        }
        
        [Serializable]
        public class PlayerState
        {
            public HyperDeckPlayerState State { get; set; }
            public bool Loop { get; set; }
            public bool SingleClip { get; set; }
            public int PlaybackSpeed { get; set; }

            public HyperDeckTime ClipTime { get; set; }
            public HyperDeckTime TimelineTime { get; set; }

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
        }

        [Serializable]
        public class StorageState
        {
            public int ActiveStorageMedia { get; set; }
            public int CurrentClipId { get; set; }

            public uint FrameRate { get; set; }
            public uint TimeScale { get; set; }
            public bool IsInterlaced { get; set; }
            public bool IsDropFrameTimecode { get; set; }

            public HyperDeckTime RemainingRecordTime { get; set; }
        }
    }
}