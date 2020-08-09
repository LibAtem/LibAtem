using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.State.Tolerance;

namespace LibAtem.State
{
    [Serializable]
    public class SettingsState
    {
        public IReadOnlyList<MultiViewerState> MultiViewers { get; set; } = new List<MultiViewerState>();
        public Dictionary<VideoSource, InputState> Inputs { get; set; } = new Dictionary<VideoSource, InputState>();

        public IReadOnlyList<TalkbackState> Talkback { get; set; } = new List<TalkbackState>();
        public IReadOnlyList<MixMinusOutputState> MixMinusOutputs { get; set; } = new List<MixMinusOutputState>();

        public bool AutoVideoMode { get; set; }
        public bool DetectedVideoMode { get; set; }

        public VideoMode VideoMode { get; set; }
        public DownConvertMode DownConvertMode { get; set; }
        public Dictionary<VideoMode, VideoMode> DownConvertVideoModes { get; } = new Dictionary<VideoMode, VideoMode>();
        public Dictionary<VideoMode, VideoMode> MultiviewVideoModes { get; } = new Dictionary<VideoMode, VideoMode>();

        public SerialMode SerialMode { get; set; }

        public SDI3GOutputLevel SDI3GLevel { get; set; }

        public bool SuperSourceCascade { get; set; }

        [Serializable]
        public class MixMinusOutputState
        {
            public bool HasAudioInputId { get; set; }
            public AudioSource AudioInputId { get; set; }
            public MixMinusMode SupportedModes { get; set; }
            public MixMinusMode Mode { get; set; }
        }

        [Serializable]
        public class TalkbackState
        {
            public bool MuteSDI { get; set; }

            //
            public Dictionary<VideoSource, TalkbackInputState> Inputs { get; set; } = new Dictionary<VideoSource, TalkbackInputState>();
        }

        [Serializable]
        public class TalkbackInputState
        {
            public bool MuteSDI { get; set; }
            public bool InputCanMuteSDI { get; set; }
            public bool CurrentInputSupportsMuteSDI { get; set; }
        }
    }

    [Serializable]
    public class InputState
    {
        public PropertiesState Properties { get; } = new PropertiesState();
        public TallyState Tally { get; } = new TallyState();

        [Serializable]
        public class PropertiesState
        {
            public string ShortName { get; set; }
            public string LongName { get; set; }
            public bool AreNamesDefault { get; set; }

            public InternalPortType InternalPortType { get; set; }
            
            public SourceAvailability SourceAvailability { get; set; }
            public MeAvailability MeAvailability { get; set; }

            public IReadOnlyList<VideoPortType> AvailableExternalPortTypes { get; set; }
            public VideoPortType CurrentExternalPortType { get; set; }
        }

        [Serializable]
        public class TallyState
        {
            public bool ProgramTally { get; set; }
            public bool PreviewTally { get; set; }
        }
    }
    
    [Serializable]
    public class MultiViewerState
    {
        [Tolerance(1)]
        public double VuMeterOpacity { get; set; }
        public PropertiesState Properties { get; } = new PropertiesState();

        public IReadOnlyList<WindowState> Windows { get; set; } = new List<WindowState>();

        [Serializable]
        public class PropertiesState
        {
            public MultiViewLayoutV8 Layout { get; set; }
            public bool ProgramPreviewSwapped { get; set; }
        }
        
        [Serializable]
        public class WindowState
        {
            public VideoSource Source { get; set; }

            public bool SupportsVuMeter { get; set; }
            public bool VuMeterEnabled { get; set; }
            
            public bool SupportsSafeArea { get; set; }
            public bool SafeAreaEnabled { get; set; }
        }
    }
}