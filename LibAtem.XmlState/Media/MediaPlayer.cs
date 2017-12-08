using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState.Media
{
    public class MediaPlayer
    {
        public MediaPlayer() : this(MediaPlayerId.One)
        {
        }

        public MediaPlayer(MediaPlayerId index)
        {
            Index = index;
            SourceType = MediaPlayerSource.Still;
            SourceIndex = 0;
        }

        [XmlAttribute("index")]
        public MediaPlayerId Index { get; set; }

        [XmlAttribute("sourceType")]
        public MediaPlayerSource SourceType { get; set; }

        [XmlAttribute("sourceIndex")]
        public uint SourceIndex { get; set; }

        [XmlAttribute("playing")]
        public AtemBool Playing { get; set; }
        public bool ShouldSerializePlaying()
        {
            return SourceType == MediaPlayerSource.Clip;
        }

        [XmlAttribute("loop")]
        public AtemBool Loop { get; set; }
        public bool ShouldSerializeLoop()
        {
            return SourceType == MediaPlayerSource.Clip;
        }

        [XmlAttribute("atBeginning")]
        public AtemBool AtBeginning { get; set; }
        public bool ShouldSerializeAtBeginning()
        {
            return SourceType == MediaPlayerSource.Clip;
        }

        [XmlAttribute("clipFrame")]
        public int ClipFrame { get; set; }
        public bool ShouldSerializeClipFrame()
        {
            return SourceType == MediaPlayerSource.Clip;
        }
    }
}