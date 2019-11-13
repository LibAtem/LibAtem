using System.Xml.Serialization;
using LibAtem.Common;

namespace LibAtem.XmlState.MixEffects.TransitionStyle
{
    public class StingerTransitionParameters
    {
        [XmlAttribute("source")]
        public StingerSource Source { get; set; }

        [XmlAttribute("preMultipliedKey")]
        public AtemBool PreMultipliedKey { get; set; }

        [XmlAttribute("clip")]
        public double Clip { get; set; }

        [XmlAttribute("gain")]
        public double Gain { get; set; }

        [XmlAttribute("invert")]
        public AtemBool Invert { get; set; }

        [XmlAttribute("clipDuration")]
        public uint ClipDuration { get; set; }

        [XmlAttribute("triggerPoint")]
        public uint TriggerPoint { get; set; }

        [XmlAttribute("mixRate")]
        public uint MixRate { get; set; }

        [XmlAttribute("preroll")]
        public uint Preroll { get; set; }
    }
}