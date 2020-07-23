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

        public bool AdvancedChromaKeyers { get; set; }
        public bool OnlyConfigurableOutputs { get; set; }
        public bool HasCameraControl { get; set; }

        public DveInfoState DVE { get; set; }
        public MultiViewInfoState MultiViewers { get; set; }

        [Serializable]
        public class DveInfoState
        {
            public bool CanRotate { get; set; }
            public bool CanScaleUp { get; set; }

            public IReadOnlyList<DVEEffect> SupportedTransitions { get; set; } = new List<DVEEffect>();
        }

        [Serializable]
        public class MultiViewInfoState
        {
            public bool CanRouteInputs { get; set; }
            public bool SupportsVuMeters { get; set; }
            public bool SupportsProgramPreviewSwapped { get; set; }
            public bool SupportsQuadrantLayout { get; set; }
            public bool SupportsToggleSafeArea { get; set; }
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