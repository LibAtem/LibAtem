using System.Collections.Generic;
using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState
{
    public class SuperSource
    {
        public const int ExpectedBoxCount = 4;

        public SuperSource()
        {
            Boxes = new List<SuperSourceBox>();
        }

        [XmlAttribute("artFillInput")]
        public VideoSource ArtFillInput { get; set; }

        [XmlAttribute("artKeyInput")]
        public VideoSource ArtKeyInput { get; set; }

        [XmlAttribute("artOption")]
        public SuperSourceArtOption ArtOption { get; set; }

        [XmlAttribute("artPreMultiplied")]
        public AtemBool ArtPreMultiplied { get; set; }

        [XmlAttribute("artClip")]
        public double ArtClip { get; set; }

        [XmlAttribute("artGain")]
        public double ArtGain { get; set; }

        [XmlAttribute("artInvertKey")]
        public AtemBool ArtInvertKey { get; set; }

        [XmlAttribute("borderEnabled")]
        public AtemBool BorderEnabled { get; set; }

        [XmlAttribute("borderBevel")]
        public BorderBevel BorderBevel { get; set; }

        [XmlAttribute("borderHue")]
        public double BorderHue { get; set; }
        [XmlAttribute("borderSaturation")]
        public double BorderSaturation { get; set; }
        [XmlAttribute("borderLuma")]
        public double BorderLuma { get; set; }

        [XmlAttribute("borderWidthOut")]
        public double BorderWidthOut { get; set; }
        [XmlAttribute("borderWidthIn")]
        public double BorderWidthIn { get; set; }
        [XmlAttribute("borderSoftnessOut")]
        public double BorderSoftnessOut { get; set; }
        [XmlAttribute("borderSoftnessIn")]
        public double BorderSoftnessIn { get; set; }
        [XmlAttribute("borderBevelPosition")]
        public double BorderBevelPosition { get; set; }
        [XmlAttribute("borderBevelSoftness")]
        public double BorderBevelSoftness { get; set; }

        [XmlAttribute("borderLightSourceDirection")]
        public double BorderLightSourceDirection { get; set; }
        [XmlAttribute("borderLightSourceAltitude")]
        public double BorderLightSourceAltitude { get; set; }

        [XmlArrayItem("Box")]
        public List<SuperSourceBox> Boxes { get; set; }
    }

    public class SuperSourceBox
    {
        public SuperSourceBox() : this(0)
        {
        }

        public SuperSourceBox(uint index)
        {
            Index = index;
        }

        [XmlAttribute("index")]
        public uint Index { get; set; }

        [XmlAttribute("enabled")]
        public AtemBool Enabled { get; set; }

        [XmlAttribute("inputSource")]
        public VideoSource InputSource { get; set; }
        
        [XmlAttribute("xPosition")]
        public double XPosition { get; set; }
        [XmlAttribute("yPosition")]
        public double YPosition { get; set; }

        [XmlAttribute("size")]
        public double Size { get; set; }

        [XmlAttribute("cropped")]
        public AtemBool Cropped { get; set; }
        [XmlAttribute("cropTop")]
        public double CropTop { get; set; }
        [XmlAttribute("cropBottom")]
        public double CropBottom { get; set; }
        [XmlAttribute("cropLeft")]
        public double CropLeft { get; set; }
        [XmlAttribute("cropRight")]
        public double CropRight { get; set; }
    }
    
}