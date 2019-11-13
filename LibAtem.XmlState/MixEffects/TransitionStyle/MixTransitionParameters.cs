using System.Xml.Serialization;

namespace LibAtem.XmlState.MixEffects.TransitionStyle
{
    public class MixTransitionParameters
    {
        [XmlAttribute("rate")]
        public uint Rate { get; set; }
    }
}