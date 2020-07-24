using System;
using System.Collections.Generic;

namespace LibAtem.State
{
    [Serializable]
    public class MediaPoolState
    {
        public IReadOnlyList<StillState> Stills { get; set; } = new List<StillState>();
        public IReadOnlyList<ClipState> Clips { get; set; } = new List<ClipState>();
        
        public uint UnassignedFrames { get; set; }

        [Serializable]
        public class StillState
        {
            public bool IsUsed { get; set; }
            public byte[] Hash { get; set; }
            public string Filename { get; set; }
        }

        [Serializable]
        public class FrameState
        {
            public bool IsUsed { get; set; }
            public byte[] Hash { get; set; } = new byte[16];
        }

        [Serializable]
        public class ClipState
        {
            public bool IsUsed { get; set; }
            public string Name { get; set; }
            public uint FrameCount { get; set; }

            public uint MaxFrames { get; set; }

            public IReadOnlyList<FrameState> Frames { get; set; } = new List<FrameState>();

            public AudioState Audio { get; } = new AudioState();


            [Serializable]
            public class AudioState
            {
                public bool IsUsed { get; set; }
                public string Name { get; set; }

                public byte[] Hash { get; set; }
            }
        }
    }
}