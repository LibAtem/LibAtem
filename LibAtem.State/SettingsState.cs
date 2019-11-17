using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Common;

namespace LibAtem.State
{
    [Serializable]
    public class SettingsState
    {
        public IReadOnlyList<MultiViewerState> MultiViewers { get; set; } = new List<MultiViewerState>();

        public VideoMode VideoMode { get; set; }
        public SerialMode SerialMode { get; set; }
    }
    
    [Serializable]
    public class MultiViewerState
    {
        public bool SupportsVuMeters { get; set; }
        
        public double VuMeterOpacity { get; set; }
        public PropertiesState Properties { get; } = new PropertiesState();

        public IReadOnlyList<WindowState> Windows { get; set; } = new List<WindowState>();

        public class PropertiesState
        {
            public MultiViewLayout Layout { get; set; }
            public bool ProgramPreviewSwapped { get; set; }
        }
        
        [Serializable]
        public class WindowState
        {
            public bool VuMeter { get; set; }
            public bool SupportsVuMeter { get; set; }
            public VideoSource Source { get; set; }
            
            public bool SafeAreaEnabled { get; set; }
        }
    }
}