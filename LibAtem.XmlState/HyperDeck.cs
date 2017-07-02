using System.Xml.Serialization;
using LibAtem.Common;

namespace AtemEmulator.State
{
    public class HyperDeck
    {
        [XmlAttribute("id")]
        public uint Id { get; set; }

        [XmlAttribute("networkAddress")]
        public string NetworkAddress { get; set; }

        [XmlAttribute("input")]
        public VideoSource Input { get; set; }

        [XmlAttribute("autoRoll")]
        public AtemBool AutoRoll { get; set; }

        [XmlAttribute("autoRollFrameDelay")]
        public uint AutoRollFrameDelay { get; set; }
    }
}