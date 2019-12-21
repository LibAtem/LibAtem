using System;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class MediaPlayerState
    {
        public SourceState Source { get; } = new SourceState();
        public ClipStatusState ClipStatus { get; set; }

        [Serializable]
        public class ClipStatusState
        {
            public bool Playing { get; set; }
            public bool Loop { get; set; }
            public bool AtBeginning { get; set; }
            public uint ClipFrame { get; set; }  
        }
        
        [Serializable]
        public class SourceState
        {
            public MediaPlayerSource SourceType { get; set; }
            public uint SourceIndex { get; set; }
        }
    }
}