using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState.MixEffects.Key
{
    public class PatternKeyParameters
    {
        [XmlAttribute("style")]
        public Pattern Style { get; set; }

        [XmlAttribute("inverse")]
        public AtemBool Inverse { get; set; }

        [XmlAttribute("size")]
        public double Size { get; set; }

        [XmlAttribute("symmetry")]
        public double Symmetry { get; set; }

        [XmlAttribute("softness")]
        public double Softness { get; set; }

        [XmlAttribute("xPosition")]
        public double XPosition { get; set; }

        [XmlAttribute("yPosition")]
        public double YPosition { get; set; }
    }
}