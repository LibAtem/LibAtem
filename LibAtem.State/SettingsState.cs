using System;
using System.Collections.Generic;
using System.Linq;
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

        public VideoMode VideoMode { get; set; }
        public SerialMode SerialMode { get; set; }

        public SDI3GOutputLevel SDI3GLevel { get; set; }

        [Serializable]
        public class HyperdeckState
        {
            public string NetworkAddress { get; set; }
            public VideoSource Input { get; set; }
            public bool AutoRoll { get; set; }
            public uint AutoRollFrameDelay { get; set; }
        }
    }

    [Serializable]
    public class InputState
    {
        public PropertiesState Properties = new PropertiesState();
        public TallyState Tally = new TallyState();
        
        [Serializable]
        public class PropertiesState
        {
            public string ShortName { get; set; }
            public string LongName { get; set; }
            // public bool AreNamesDefault { get; set; }
            
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
            public bool SupportsSafeArea { get; set; }
        }
    }
}