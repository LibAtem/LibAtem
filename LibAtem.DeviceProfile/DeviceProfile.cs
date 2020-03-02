using System.Collections.Generic;
using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.DeviceProfile
{
    [XmlRoot("DeviceProfile", IsNullable = false)]
    public class DeviceProfile
    {
        public ModelId Model { get; set; }

        public string Product { get; set; }
        
        public uint MixEffectBlocks { get; set; }

        public List<DevicePort> Sources { get; set; }

        public List<AudioSource> AudioSources { get; set; }

        // public uint ColorGenerators { get; set; }

        public uint Auxiliaries { get; set; }

        public uint DownstreamKeys { get; set; }

        public uint UpstreamKeys { get; set; }

        public bool RoutableKeyMasks { get; set; }

        public uint HyperDecks { get; set; }

        public uint Stingers { get; set; }

        public MultiView MultiView { get; set; }

        public uint DVE { get; set; }

        public uint SuperSource { get; set; }

        public uint MediaPlayers { get; set; }

        public uint MediaPoolClips { get; set; }

        public uint MediaPoolStills { get; set; }

        public uint MacroCount { get; set; }

        public uint SerialPort { get; set; }

        public bool AudioMonitor { get; set; }

        public VideoModeSet VideoModes { get; set; }

        public uint MixMinusOutputs { get; set; }
    }

    public class VideoModeSet
    {
        public List<VideoMode> SupportedModes { get; set; }

        /*
        [XmlAttribute("minimumSupported")]
        public VideoModeStandard MinimumSupported { get; set; }
        [XmlAttribute("maximumSupported")]
        public VideoModeStandard MaximumSupported { get; set; }

        [XmlAttribute("downConvertAbove")]
        public VideoModeStandard DownConvertAbove { get; set; }
        */

        public MaxFramesSet MaxFrames { get; set; }
    }

    public class MaxFramesSet
    {
        [XmlAttribute("sd")]
        public uint SD { get; set; }

        [XmlAttribute("_720")]
        public uint _720 { get; set; }

        [XmlAttribute("_1080")]
        public uint _1080 { get; set; }

        [XmlAttribute("_4k")]
        public uint _4K { get; set; }
    }

    public class DevicePort
    {
        [XmlAttribute("id")]
        public VideoSource Id { get; set; }

        [XmlElement("Port")]
        public List<ExternalPortType> Port { get; set; }
    }

    public class MultiView
    {
        public uint Count { get; set; }

        public bool VuMeters { get; set; }

        public bool CanSwapPreviewProgram { get; set; }

        // TODO - is this supposed to be here?
        public bool Supports1080p { get; set; }

        public bool CanRouteInputs { get; set; }

        public bool CanToggleSafeArea { get; set; }

    }
}