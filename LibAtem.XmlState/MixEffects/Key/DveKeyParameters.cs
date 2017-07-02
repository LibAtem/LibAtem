using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState.MixEffects.Key
{
    public class DveKeyParameters
    {
        [XmlAttribute("maskEnabled")]
        public AtemBool MaskEnabled { get; set; }

        [XmlAttribute("maskTop")]
        public double MaskTop { get; set; }
        [XmlAttribute("maskBottom")]
        public double MaskBottom { get; set; }
        [XmlAttribute("maskLeft")]
        public double MaskLeft { get; set; }
        [XmlAttribute("maskRight")]
        public double MaskRight { get; set; }

        [XmlAttribute("shadowEnabled")]
        public AtemBool ShadowEnabled { get; set; }

        [XmlAttribute("lightSourceDirection")]
        public double LightSourceDirection { get; set; }
        [XmlAttribute("lightSourceAltitude")]
        public double LightSourceAltitude { get; set; }

        [XmlAttribute("borderEnabled")]
        public AtemBool BorderEnabled { get; set; }
        [XmlAttribute("borderStyle")]
        public BorderBevel BorderStyle { get; set; }
        [XmlAttribute("borderBevelHue")]
        public double BorderBevelHue { get; set; }
        [XmlAttribute("borderBevelSaturation")]
        public double BorderBevelSaturation { get; set; }
        [XmlAttribute("borderBevelLuma")]
        public double BorderBevelLuma { get; set; }

        [XmlAttribute("borderWidthOut")]
        public double BorderWidthOut { get; set; }
        [XmlAttribute("borderWidthIn")]
        public double BorderWidthIn { get; set; }
        [XmlAttribute("borderSoftnessOut")]
        public double BorderSoftnessOut { get; set; }
        [XmlAttribute("borderSoftnessIn")]
        public double BorderSoftnessIn { get; set; }
        [XmlAttribute("borderBevelOpacity")]
        public double BorderBevelOpacity { get; set; }
        [XmlAttribute("borderBevelPosition")]
        public double BorderBevelPosition { get; set; }
        [XmlAttribute("borderBevelSoftness")]
        public double BorderBevelSoftness { get; set; }
    }
}