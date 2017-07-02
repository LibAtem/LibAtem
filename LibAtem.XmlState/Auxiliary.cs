using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState
{
    public class Auxiliary
    {
        public Auxiliary() : this(VideoSource.Auxilary1)
        {
        }

        public Auxiliary(VideoSource id)
        {
            Id = id;
            Input = VideoSource.ColorBars;
        }

        [XmlAttribute("id")]
        public VideoSource Id { get; set; }

        [XmlAttribute("input")]
        public VideoSource Input { get; set; }
    }
}