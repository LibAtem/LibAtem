using System.Xml.Serialization;

namespace LibAtem.XmlState.MixEffects.Key
{
    public class FlyKeyParameters
    {
        [XmlAttribute("enabled")]
        public AtemBool Enabled { get; set; }

        [XmlAttribute("xPosition")]
        public double XPosition { get; set; }
        [XmlAttribute("yPosition")]
        public double YPosition { get; set; }

        [XmlAttribute("xSize")]
        public double XSize { get; set; }
        [XmlAttribute("ySize")]
        public double YSize { get; set; }

        [XmlAttribute("rotation")]
        public double Rotation { get; set; }
        [XmlAttribute("rate")]
        public int Rate { get; set; }
    }
}