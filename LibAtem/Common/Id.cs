using System.Xml.Serialization;

namespace LibAtem.Common
{
    public enum MixEffectBlockId
    {
        [XmlEnum("0")]
        One = 0,
        [XmlEnum("1")]
        Two = 1
    }

    public enum MediaPlayerId
    {
        [XmlEnum("0")]
        One = 0,
        [XmlEnum("1")]
        Two = 1,
        [XmlEnum("2")]
        Three = 2,
        [XmlEnum("3")]
        Four = 3,
    }

    public enum DownstreamKeyId
    {
        [XmlEnum("0")]
        One = 0,
        [XmlEnum("1")]
        Two = 1
    }
}
