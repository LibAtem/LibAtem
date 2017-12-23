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

    public enum UpstreamKeyId
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

    public enum SuperSourceBoxId
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
    
    public enum AuxiliaryId
    {
        [XmlEnum("0")]
        One = 0,
        [XmlEnum("1")]
        Two = 1,
        [XmlEnum("2")]
        Three = 2,
        [XmlEnum("3")]
        Four = 3,
        [XmlEnum("4")]
        Five = 4,
        [XmlEnum("5")]
        Six = 5,
    }

    public enum ColorGeneratorId
    {
        [XmlEnum("0")]
        One = 0,
        [XmlEnum("1")]
        Two = 1,
    }

    public enum FlyKeyKeyFrameId
    {
        [XmlEnum("0")]
        One = 0,
        [XmlEnum("1")]
        Two = 1,
    }

    public enum FlyKeyLocation
    {
        CentreOfKey  = 0,
        TopLeft      = 1,
        TopCentre    = 2,
        TopRight     = 3,
        MiddleLeft   = 4,
        MiddleCentre = 5,
        MiddleRight  = 6,
        BottomLeft   = 7,
        BottomCentre = 8,
        BottomRight  = 9,
    }
}
