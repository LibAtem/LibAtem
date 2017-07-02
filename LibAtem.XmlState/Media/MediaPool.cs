using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using LibAtem.Util;

namespace LibAtem.XmlState.Media
{
    public class MediaPool
    {
        public MediaPool()
        {
            Stills = new List<MediaPoolStill>();
            Clips = new List<MediaPoolClip>();
        }

        public MediaPool(uint stillCount, uint clipCount)
        {
            Stills = Collections.Repeat(i => new MediaPoolStill(i), stillCount).ToList();
            Clips = Collections.Repeat(i => new MediaPoolClip(i), clipCount).ToList();
        }

        [XmlArrayItem("Still")]
        public List<MediaPoolStill> Stills { get; set; }
        public bool ShouldSerializeStills()
        {
            return Stills != null && Stills.Count > 0;
        }
        
        [XmlArrayItem("Clip")]
        public List<MediaPoolClip> Clips { get; set; }
        public bool ShouldSerializeClips()
        {
            return Clips != null && Clips.Count > 0;
        }
    }

    public class MediaPoolStill
    {
        public MediaPoolStill()
        {    
        }

        public MediaPoolStill(uint index)
        {
            Index = index;
        }

        [XmlAttribute("index")]
        public uint Index { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }
    }

    public class MediaPoolClip
    {
        public MediaPoolClip() : this(0)
        {
        }

        public MediaPoolClip(uint index)
        {
            Index = index;
            Name = string.Empty;
            Frames = new List<MediaPoolFrame>();
            Audio = new MediaPoolAudio();
        }

        [XmlAttribute("index")]
        public uint Index { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("Frame")]
        public List<MediaPoolFrame> Frames { get; set; }

        public MediaPoolAudio Audio { get; set; }
        public bool ShouldSerializeAudio()
        {
            return Audio != null && Audio.Name != null && Audio.Name != "";
        }
    }

    public class MediaPoolFrame
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }
    }

    public class MediaPoolAudio
    {
        public MediaPoolAudio()
        {
            Name = "";
        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }
    }
    
}