using System.Xml.Serialization;

namespace LibAtem.XmlState
{
    public class ColorGenerator
    {
        [XmlAttribute("index")]
        public uint Index { get; set; }
        
        [XmlAttribute("hue")]
        public double Hue { get; set; }

        [XmlAttribute("saturation")]
        public double Saturation { get; set; }

        [XmlAttribute("luma")]
        public double Luma { get; set; }
    }
}