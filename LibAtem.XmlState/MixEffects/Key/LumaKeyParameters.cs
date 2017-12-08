using System.Xml.Serialization;

namespace LibAtem.XmlState.MixEffects.Key
{
    public class LumaKeyParameters
    {
        [XmlAttribute("preMultiplied")]
        public AtemBool PreMultiplied { get; set; }

        [XmlAttribute("clip")]
        public double Clip { get; set; }

        [XmlAttribute("gain")]
        public double Gain { get; set; }

        [XmlAttribute("inverse")]
        public AtemBool Invert { get; set; }
    }
}