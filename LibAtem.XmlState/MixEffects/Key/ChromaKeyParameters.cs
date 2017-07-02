using System.Xml.Serialization;

namespace LibAtem.XmlState.MixEffects.Key
{
    public class ChromaKeyParameters
    {
        [XmlAttribute("hue")]
        public double Hue { get; set; }

        [XmlAttribute("gain")]
        public double Gain { get; set; }

        [XmlAttribute("ySuppress")]
        public double YSuppress { get; set; }

        [XmlAttribute("lift")]
        public double Lift { get; set; }

        [XmlAttribute("narrow")]
        public AtemBool Narrow { get; set; }
    }
}