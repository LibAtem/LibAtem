using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState.MixEffects.TransitionStyle
{
    public class DipTransitionParameters
    {
        [XmlAttribute("rate")]
        public uint Rate { get; set; }

        [XmlAttribute("input")]
        public VideoSource Input { get; set; }
    }
}