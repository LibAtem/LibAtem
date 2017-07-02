using System.Xml.Serialization;
using LibAtem.Common;

namespace AtemEmulator.State.MixEffects.TransitionStyle
{
    public class DipTransitionParameters
    {
        [XmlAttribute("rate")]
        public uint Rate { get; set; }

        [XmlAttribute("input")]
        public VideoSource Input { get; set; }
    }
}