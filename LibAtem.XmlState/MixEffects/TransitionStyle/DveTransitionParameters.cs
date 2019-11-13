using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState.MixEffects.TransitionStyle
{
    public class DveTransitionParameters
    {
        [XmlAttribute("rate")]
        public uint Rate { get; set; }

        [XmlAttribute("logoRate")]
        public uint LogoRate { get; set; }
        
        [XmlAttribute("reverseDirection")]
        public AtemBool ReverseDirection { get; set; }

        [XmlAttribute("flipFlop")]
        public AtemBool FlipFlop { get; set; }

        [XmlAttribute("effect")]
        public DVEEffect Effect { get; set; }

        [XmlAttribute("fillSource")]
        public VideoSource FillSource { get; set; }

        [XmlAttribute("keySource")]
        public VideoSource KeySource { get; set; }

        [XmlAttribute("enableKey")]
        public AtemBool EnableKey { get; set; }

        [XmlAttribute("preMultipliedKey")]
        public AtemBool PreMultipliedKey { get; set; }

        [XmlAttribute("clip")]
        public double Clip { get; set; }

        [XmlAttribute("gain")]
        public double Gain { get; set; }

        [XmlAttribute("invertKey")]
        public AtemBool InvertKey { get; set; }
    }
}