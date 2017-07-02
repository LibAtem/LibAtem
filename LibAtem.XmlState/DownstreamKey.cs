using System.Xml.Serialization;
using LibAtem.Common;

namespace AtemEmulator.State
{
    public class DownstreamKey
    {
        [XmlAttribute("index")]
        public DownstreamKeyId Index { get; set; }

        [XmlAttribute("fillSource")]
        public VideoSource FillSource { get; set; }
        [XmlAttribute("keySource")]
        public VideoSource CutSource { get; set; }

        [XmlAttribute("rate")]
        public uint Rate { get; set; }

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

        [XmlAttribute("preMultipliedKey")]
        public AtemBool PreMultipliedKey { get; set; }

        [XmlAttribute("clip")]
        public double Clip { get; set; }

        [XmlAttribute("gain")]
        public double Gain { get; set; }

        [XmlAttribute("invert")]
        public AtemBool Invert { get; set; }

        [XmlAttribute("onAir")]
        public AtemBool OnAir { get; set; }

        [XmlAttribute("tie")]
        public AtemBool Tie { get; set; }
    }
}