using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState.MixEffects.TransitionStyle
{
    public class WipeTransitionParameters
    {
        [XmlAttribute("rate")]
        public uint Rate { get; set; }

        [XmlAttribute("pattern")]
        public Pattern Pattern { get; set; }

        [XmlAttribute("symmetry")]
        public double Symmetry { get; set; }

        [XmlAttribute("xPosition")]
        public double XPosition { get; set; }

        [XmlAttribute("yPosition")]
        public double YPosition { get; set; }

        [XmlAttribute("reverseDirection")]
        public AtemBool ReverseDirection { get; set; }

        [XmlAttribute("flipFlip")]
        public AtemBool FlipFlop { get; set; }

        [XmlAttribute("borderInput")]
        public VideoSource BorderInput { get; set; }

        [XmlAttribute("borderWidth")]
        public double BorderWidth { get; set; }

        [XmlAttribute("borderSoftness")]
        public double BorderSoftness { get; set; }
    }
}