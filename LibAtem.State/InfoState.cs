using System;
using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class InfoState
    {
        public ProtocolVersion Version { get; set; }

        public bool TimecodeLocked { get; set; }
        public Timecode LastTimecode { get; set; }

        public ModelId Model { get; set; }
        public string ProductName { get; set; }

        public IReadOnlyList<VideoModeInfo> SupportedVideoModes { get; set; } = new List<VideoModeInfo>();
        
        public bool SupportsAutoVideoMode { get; set; }

        public DveInfo DVE { get; set; }

        [Serializable]
        public class DveInfo
        {
            public bool CanRotate { get; set; }
            public bool CanScaleUp { get; set; }

            public IReadOnlyList<DVEEffect> SupportedTransitions { get; set; } = new List<DVEEffect>();
        }
    }

    [Serializable]
    public class VideoModeInfo
    {
        public VideoMode Mode { get; set; }

        public bool RequiresReconfig { get; set; }

        public VideoMode[] MultiviewModes { get; set; } = new VideoMode[0];
        public VideoMode[] DownConvertModes { get; set; } = new VideoMode[0];
    }

    [Serializable]
    public class Timecode
    {
        public uint Hour { get; set; }
        public uint Minute { get; set; }
        public uint Second { get; set; }
        public uint Frame { get; set; }

        public bool DropFrame { get; set; }
    }
}