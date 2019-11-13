using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState.Settings
{
    public class AtemSettings
    {
        public AtemSettings()
        {
            MultiViewVideoModes = new List<MultiViewVideoMode>();
            AudioMonitors = new List<AudioMonitor>();
            Inputs = new List<Input>();
            MediaPool = new MediaPoolSettings();
            MultiViews = new List<MultiView>();
            ButtonMapping = new List<ButtonMap>();
        }

        [XmlAttribute("videoMode")]
        public VideoMode VideoMode { get; set; }

        [XmlAttribute("downConvertMode")]
        public DownConvertMode DownConvertMode { get; set; }

        [XmlAttribute("abDirect")]
        public AtemBool AbDirect { get; set; } // Client side only

        [XmlAttribute("cameraAux")]
        public int CameraAux { get; set; } // Client side only

        [XmlAttribute]
        public SDI3GOutputLevel SDI3GOutputLevel { get; set; }

        public List<MultiViewVideoMode> MultiViewVideoModes { get; set; }

        public List<DownConvertedHDVideoMode> DownConvertedHDVideoModes { get; set; }
        public bool ShouldSerializeDownConvertedHDVideoModes()
        {
            return DownConvertedHDVideoModes != null && DownConvertedHDVideoModes.Count > 0;
        }

        public List<AudioMonitor> AudioMonitors { get; set; }

        public Talkback Talkback { get; set; }

        public List<Input> Inputs { get; set; }

        public MediaPoolSettings MediaPool { get; set; }
        public bool ShouldSerializeMediaPool()
        {
            return MediaPool != null && MediaPool.Clips.Count > 0;
        }

        public List<MultiView> MultiViews { get; set; }

        [XmlArrayItem("Button")]
        public List<ButtonMap> ButtonMapping { get; set; }

        public List<Remote> Remotes { get; set; }
        public bool ShouldSerializeRemotes()
        {
            return Remotes != null && Remotes.Count > 0;
        }

        public UpstreamKeys UpstreamKeys { get; set; }
    }

    public class MultiViewVideoMode
    {
        [XmlAttribute("coreVideoMode")]
        public VideoMode CoreVideoMode { get; set; }

        [XmlAttribute("multiViewVideoMode")]
        public VideoMode MultiViewMode { get; set; }
    }

    public class DownConvertedHDVideoMode
    {
        [XmlAttribute("coreVideoMode")]
        public VideoMode CoreVideoMode { get; set; }

        [XmlAttribute("downConvertedHDVideoMode")]
        public VideoMode DownConvertedMode { get; set; }
    }

    public class AudioMonitor
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("monitorEnabled")]
        public AtemBool MonitorEnabled { get; set; }
    }

    public class Input
    {
        public Input() : this(VideoSource.Input1, "Cam?", "Camera ?", ExternalPortType.SDI)
        {
        }

        public Input(VideoSource id, string shortName, string longName, ExternalPortType type)
        {
            Id = id;
            ShortName = shortName;
            LongName = longName;
            PortType = type;
        }

        [XmlAttribute("id")]
        public VideoSource Id { get; set; }

        [XmlAttribute("shortName")]
        public string ShortName { get; set; }

        [XmlAttribute("longName")]
        public string LongName { get; set; }

        [XmlAttribute("externalPortType")]
        public ExternalPortType PortType { get; set; }
    }

    public class ButtonMap
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("externalInputIndex")]
        public int Input { get; set; }

        [XmlAttribute("mappedToCamera")]
        public AtemBool MappedToCamera { get; set; }
    }

    public class Remote
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("function")]
        public RemoteFunction Function { get; set; }
    }

    public enum RemoteFunction
    {
        None,
  
        [XmlEnum("PTZ VISCA")]
        PTZVISCA,
        //TODO
    }

    public class Talkback
    {
        [XmlAttribute("sdiMuted")]
        public AtemBool SdiMuted { get; set; }
    }

    public class UpstreamKeys
    {
        [XmlAttribute("sizeLink")]
        public AtemBool SizeLink { get; set; }
    }
}