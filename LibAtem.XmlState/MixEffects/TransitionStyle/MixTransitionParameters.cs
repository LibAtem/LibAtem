using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects.TransitionStyle
{
    public class MixTransitionParameters
    {
        [XmlAttribute("rate")]
        public uint Rate { get; set; }
    }
}