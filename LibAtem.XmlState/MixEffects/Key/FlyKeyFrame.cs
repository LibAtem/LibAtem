using System.Xml.Serialization;

namespace LibAtem.XmlState.MixEffects.Key
{
    public class FlyKeyFrame
    {
        [XmlAttribute("xSize")]
        public double XSize { get; set; }
        [XmlAttribute("ySize")]
        public double YSize { get; set; }

        [XmlAttribute("xPosition")]
        public double XPosition { get; set; }
        [XmlAttribute("yPosition")]
        public double YPosition { get; set; }

        [XmlAttribute("rotation")]
        public double Rotation { get; set; }

        [XmlAttribute("borderWidthOut")]
        public double BorderWidthOut { get; set; }
        [XmlAttribute("borderWidthIn")]
        public double BorderWidthIn { get; set; }

        [XmlAttribute("borderSoftnessOut")]
        public uint BorderSoftnessOut { get; set; }
        [XmlAttribute("borderSoftnessIn")]
        public uint BorderSoftnessIn { get; set; }

        [XmlAttribute("borderBevelSoftness")]
        public double BorderBevelSoftness { get; set; }
        [XmlAttribute("borderBevelPosition")]
        public double BorderBevelPosition { get; set; }

        [XmlAttribute("borderOpacity")]
        public uint BorderOpacity { get; set; }
        [XmlAttribute("borderHue")]
        public double BorderHue { get; set; }
        [XmlAttribute("borderSaturation")]
        public double BorderSaturation { get; set; }
        [XmlAttribute("borderLuma")]
        public double BorderLuma { get; set; }

        [XmlAttribute("borderLightSourceDirection")]
        public double BorderLightSourceDirection { get; set; }
        [XmlAttribute("borderLightSourceAltitude")]
        public double BorderLightSourceAltitude { get; set; }

        [XmlAttribute("maskTop")]
        public double MaskTop { get; set; }
        [XmlAttribute("maskBottom")]
        public double MaskBottom { get; set; }
        [XmlAttribute("maskLeft")]
        public double MaskLeft { get; set; }
        [XmlAttribute("maskRight")]
        public double MaskRight { get; set; }
    }
}