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

        public IReadOnlyList<HyperdeckState> Hyperdecks { get; set; } = new List<HyperdeckState>();
        public IReadOnlyDictionary<TalkbackChannel, TalkbackState> Talkback { get; set; }
        public IReadOnlyList<MixMinusOutputState> MixMinusOutputs { get; set; } = new List<MixMinusOutputState>();

        public VideoMode VideoMode { get; set; }
        public DownConvertMode DownConvertMode { get; set; }
        public VideoMode DownConvertVideoMode { get; set; }

        public SerialMode SerialMode { get; set; }

        public SDI3GOutputLevel SDI3GLevel { get; set; }

        public bool SuperSourceCascade { get; set; }

        [Serializable]
        public class HyperdeckState
        {
            public string NetworkAddress { get; set; }
            public VideoSource Input { get; set; }
            public bool AutoRoll { get; set; }
            public uint AutoRollFrameDelay { get; set; }
        }


        [Serializable]
        public class MixMinusOutputState
        {
            public AudioSource AudioInputId { get; set; }
            public MixMinusMode SupportedModes { get; set; }
            public MixMinusMode Mode { get; set; }
        }

        [Serializable]
        public class TalkbackState
        {
            public bool MuteSDI { get; set; }

            //
            public IReadOnlyList<TalkbackInputState> Inputs { get; set; } = new List<TalkbackInputState>();
        }

        [Serializable]
        public class TalkbackInputState
        {
            //
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
            // public bool AreNamesDefault { get; set; }

            public InternalPortType InternalPortType { get; set; }
            
            public SourceAvailability SourceAvailability { get; set; }
            public MeAvailability MeAvailability { get; set; }

            public ExternalPortTypeFlags AvailableExternalPortTypes { get; set; }
            public ExternalPortTypeFlags CurrentExternalPortType { get; set; }
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
        public bool SupportsVuMeters { get; set; }
        public bool SupportsProgramPreviewSwapped { get; set; }
        public bool SupportsQuadrantLayout { get; set; }
        public bool SupportsToggleSafeArea { get; set; }

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
            public bool VuMeter { get; set; }
            public bool SupportsVuMeter { get; set; }
            public VideoSource Source { get; set; }
            
            public bool SafeAreaEnabled { get; set; }
            // public bool SupportsSafeArea { get; set; }
        }
    }
}