﻿using System.Xml.Serialization;

namespace LibAtem.Common
{
    public enum ModelId
    {
        Unknown = 0,
        TVStudio = 1,
        OneME = 2,
        TwoME = 3,
        PS4K = 4,
        OneME4K = 5,
        TwoMe4K = 6,
        TwoMEBS4K = 7,
        TVStudioHD = 8,
        // TVStudioProHD = 9,
        // TVStudioPro4K = 10,
        Constellation8K = 11,
    }

    public enum MixEffectBlockId
    {
        [XmlEnum("0")]
        One = 0,
        [XmlEnum("1")]
        Two = 1,
        [XmlEnum("2")]
        Three = 2,
        [XmlEnum("3")]
        Four = 3
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
        Two = 1,
        [XmlEnum("2")]
        Three = 2,
        [XmlEnum("3")]
        Four = 3
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

    public enum SuperSourceId
    {
        [XmlEnum("0")]
        One = 0,
        [XmlEnum("1")]
        Two = 1,
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
        One = 1,
        [XmlEnum("1")]
        Two = 2,
    }

    public enum FlyKeyLocation
    {
        CentreOfKey = 0,
        TopLeft = 1,
        TopCentre = 2,
        TopRight = 3,
        MiddleLeft = 4,
        MiddleCentre = 5,
        MiddleRight = 6,
        BottomLeft = 7,
        BottomCentre = 8,
        BottomRight = 9,
    }

    public enum TalkbackChannel
    {
        Production = 0,
        Engineering = 1
    }
}
