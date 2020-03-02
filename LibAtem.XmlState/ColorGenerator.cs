using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState
{
    public class ColorGenerator
    {
        [XmlAttribute("index")]
        public ColorGeneratorId Index { get; set; }
        
        [XmlAttribute("hue")]
        public double Hue { get; set; }

        [XmlAttribute("saturation")]
        public double Saturation { get; set; }

        [XmlAttribute("luma")]
        public double Luma { get; set; }
    }
}