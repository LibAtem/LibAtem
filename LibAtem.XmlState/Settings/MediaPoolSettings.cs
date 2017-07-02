using System.Collections.Generic;
using System.Xml.Serialization;

namespace LibAtem.XmlState.Settings
{
    public class MediaPoolSettings
    {
        public MediaPoolSettings()
        {
            Clips = new List<MediaPoolClipSettings>();
        }

        [XmlArrayItem("Clip")]
        public List<MediaPoolClipSettings> Clips { get; set; }
    }

    public class MediaPoolClipSettings
    {
        public MediaPoolClipSettings() : this(0, 800)
        {
        }

        public MediaPoolClipSettings(int index, uint maxFrames)
        {
            Index = index;
            MaxFrameCount = maxFrames;
        }

        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("maxFrameCount")]
        public uint MaxFrameCount { get; set; }
    }
}