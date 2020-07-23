using System;
using System.Linq;
using System.Xml.Serialization;
using LibAtem.Util;

namespace LibAtem.Common
{
    public enum VideoSource
    {
        [VideoSourceType(InternalPortType.Black, 0)]
        [XmlEnum("0")]
        Black = 0,

        [VideoSourceType(InternalPortType.External, 1)]
        [XmlEnum("1")]
        Input1 = 1,
        [VideoSourceType(InternalPortType.External, 2)]
        [XmlEnum("2")]
        Input2 = 2,
        [VideoSourceType(InternalPortType.External, 3)]
        [XmlEnum("3")]
        Input3 = 3,
        [VideoSourceType(InternalPortType.External, 4)]
        [XmlEnum("4")]
        Input4 = 4,
        [VideoSourceType(InternalPortType.External, 5)]
        [XmlEnum("5")]
        Input5 = 5,
        [VideoSourceType(InternalPortType.External, 6)]
        [XmlEnum("6")]
        Input6 = 6,
        [VideoSourceType(InternalPortType.External, 7)]
        [XmlEnum("7")]
        Input7 = 7,
        [VideoSourceType(InternalPortType.External, 8)]
        [XmlEnum("8")]
        Input8 = 8,
        [VideoSourceType(InternalPortType.External, 9)]
        [XmlEnum("9")]
        Input9 = 9,
        [VideoSourceType(InternalPortType.External, 10)]
        [XmlEnum("10")]
        Input10 = 10,
        [VideoSourceType(InternalPortType.External, 11)]
        [XmlEnum("11")]
        Input11 = 11,
        [VideoSourceType(InternalPortType.External, 12)]
        [XmlEnum("12")]
        Input12 = 12,
        [VideoSourceType(InternalPortType.External, 13)]
        [XmlEnum("13")]
        Input13 = 13,
        [VideoSourceType(InternalPortType.External, 14)]
        [XmlEnum("14")]
        Input14 = 14,
        [VideoSourceType(InternalPortType.External, 15)]
        [XmlEnum("15")]
        Input15 = 15,
        [VideoSourceType(InternalPortType.External, 16)]
        [XmlEnum("16")]
        Input16 = 16,
        [VideoSourceType(InternalPortType.External, 17)]
        [XmlEnum("17")]
        Input17 = 17,
        [VideoSourceType(InternalPortType.External, 18)]
        [XmlEnum("18")]
        Input18 = 18,
        [VideoSourceType(InternalPortType.External, 19)]
        [XmlEnum("19")]
        Input19 = 19,
        [VideoSourceType(InternalPortType.External, 20)]
        [XmlEnum("20")]
        Input20 = 20,
        [VideoSourceType(InternalPortType.External, 21)]
        [XmlEnum("21")]
        Input21 = 21,
        [VideoSourceType(InternalPortType.External, 22)]
        [XmlEnum("22")]
        Input22 = 22,
        [VideoSourceType(InternalPortType.External, 23)]
        [XmlEnum("23")]
        Input23 = 23,
        [VideoSourceType(InternalPortType.External, 24)]
        [XmlEnum("24")]
        Input24 = 24,
        [VideoSourceType(InternalPortType.External, 25)]
        [XmlEnum("25")]
        Input25 = 25,
        [VideoSourceType(InternalPortType.External, 26)]
        [XmlEnum("26")]
        Input26 = 26,
        [VideoSourceType(InternalPortType.External, 27)]
        [XmlEnum("27")]
        Input27 = 27,
        [VideoSourceType(InternalPortType.External, 28)]
        [XmlEnum("28")]
        Input28 = 28,
        [VideoSourceType(InternalPortType.External, 29)]
        [XmlEnum("29")]
        Input29 = 29,
        [VideoSourceType(InternalPortType.External, 30)]
        [XmlEnum("30")]
        Input30 = 30,
        [VideoSourceType(InternalPortType.External, 31)]
        [XmlEnum("31")]
        Input31 = 31,
        [VideoSourceType(InternalPortType.External, 32)]
        [XmlEnum("32")]
        Input32 = 32,
        [VideoSourceType(InternalPortType.External, 33)]
        [XmlEnum("33")]
        Input33 = 33,
        [VideoSourceType(InternalPortType.External, 34)]
        [XmlEnum("34")]
        Input34 = 34,
        [VideoSourceType(InternalPortType.External, 35)]
        [XmlEnum("35")]
        Input35 = 35,
        [VideoSourceType(InternalPortType.External, 36)]
        [XmlEnum("36")]
        Input36 = 36,
        [VideoSourceType(InternalPortType.External, 37)]
        [XmlEnum("37")]
        Input37 = 37,
        [VideoSourceType(InternalPortType.External, 38)]
        [XmlEnum("38")]
        Input38 = 38,
        [VideoSourceType(InternalPortType.External, 39)]
        [XmlEnum("39")]
        Input39 = 39,
        [VideoSourceType(InternalPortType.External, 40)]
        [XmlEnum("40")]
        Input40 = 40,

        [VideoSourceType(InternalPortType.ColorBars, 0)]
        [XmlEnum("1000")]
        ColorBars = 1000,

        [VideoSourceType(InternalPortType.ColorGenerator, 1)]
        [XmlEnum("2001")]
        Color1 = 2001,
        [VideoSourceType(InternalPortType.ColorGenerator, 2)]
        [XmlEnum("2002")]
        Color2 = 2002,

        [VideoSourceType(InternalPortType.MediaPlayerFill, 1)]
        [XmlEnum("3010")]
        MediaPlayer1 = 3010,
        [VideoSourceType(InternalPortType.MediaPlayerKey, 1)]
        [XmlEnum("3011")]
        MediaPlayer1Key = 3011,
        [VideoSourceType(InternalPortType.MediaPlayerFill, 2)]
        [XmlEnum("3020")]
        MediaPlayer2 = 3020,
        [VideoSourceType(InternalPortType.MediaPlayerKey, 2)]
        [XmlEnum("3021")]
        MediaPlayer2Key = 3021,
        [VideoSourceType(InternalPortType.MediaPlayerFill, 3)]
        [XmlEnum("3030")]
        MediaPlayer3 = 3030,
        [VideoSourceType(InternalPortType.MediaPlayerKey, 3)]
        [XmlEnum("3031")]
        MediaPlayer3Key = 3031,
        [VideoSourceType(InternalPortType.MediaPlayerFill, 4)]
        [XmlEnum("3040")]
        MediaPlayer4 = 3040,
        [VideoSourceType(InternalPortType.MediaPlayerKey, 4)]
        [XmlEnum("3041")]
        MediaPlayer4Key = 3041,

        [VideoSourceType(InternalPortType.Mask, 1)]
        [XmlEnum("4010")]
        Key1Mask = 4010,
        [VideoSourceType(InternalPortType.Mask, 2)]
        [XmlEnum("4020")]
        Key2Mask = 4020,
        [VideoSourceType(InternalPortType.Mask, 3, 1)]
        [XmlEnum("4030")]
        Key3Mask = 4030,
        [VideoSourceType(InternalPortType.Mask, 4, 2)]
        [XmlEnum("4040")]
        Key4Mask = 4040,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("4050")]
        Key5Mask = 4050,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("4060")]
        Key6Mask = 4060,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("4070")]
        Key7Mask = 4070,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("4080")]
        Key8Mask = 4080,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("4090")]
        Key9Mask = 4090,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("4100")]
        Key10Mask = 4100,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("4110")]
        Key11Mask = 4110,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("4120")]
        Key12Mask = 4120,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("413")]
        Key13Mask = 4130,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("4140")]
        Key14Mask = 4140,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("4150")]
        Key15Mask = 4150,
        [VideoSourceType(InternalPortType.Mask, -1)]
        [XmlEnum("4160")]
        Key16Mask = 4160,

        [VideoSourceType(InternalPortType.Mask, 0)]
        [XmlEnum("5010")]
        DSK1Mask = 5010,
        [VideoSourceType(InternalPortType.Mask, 0)]
        [XmlEnum("5020")]
        DSK2Mask = 5020,
        [VideoSourceType(InternalPortType.Mask, 0)]
        [XmlEnum("5030")]
        DSK3Mask = 5030,
        [VideoSourceType(InternalPortType.Mask, 0)]
        [XmlEnum("5040")]
        DSK4Mask = 5040,

        [VideoSourceType(InternalPortType.SuperSource, 1)]
        [XmlEnum("6000")]
        SuperSource = 6000,
        [VideoSourceType(InternalPortType.SuperSource, 1)]
        [XmlEnum("6001")]
        SuperSource2 = 6001,

        [VideoSourceType(InternalPortType.MEOutput, 0)]
        [XmlEnum("7001")]
        CleanFeed1 = 7001,
        [VideoSourceType(InternalPortType.MEOutput, 0)]
        [XmlEnum("7002")]
        CleanFeed2 = 7002,
        [VideoSourceType(InternalPortType.MEOutput, 0)]
        [XmlEnum("7003")]
        CleanFeed3 = 7003,
        [VideoSourceType(InternalPortType.MEOutput, 0)]
        [XmlEnum("7004")]
        CleanFeed4 = 7004,

        [VideoSourceType(InternalPortType.Auxiliary, 1)]
        [XmlEnum("8001")]
        Auxilary1 = 8001,
        [VideoSourceType(InternalPortType.Auxiliary, 2)]
        [XmlEnum("8002")]
        Auxilary2 = 8002,
        [VideoSourceType(InternalPortType.Auxiliary, 3)]
        [XmlEnum("8003")]
        Auxilary3 = 8003,
        [VideoSourceType(InternalPortType.Auxiliary, 4)]
        [XmlEnum("8004")]
        Auxilary4 = 8004,
        [VideoSourceType(InternalPortType.Auxiliary, 5)]
        [XmlEnum("8005")]
        Auxilary5 = 8005,
        [VideoSourceType(InternalPortType.Auxiliary, 6)]
        [XmlEnum("8006")]
        Auxilary6 = 8006,

        [VideoSourceType(InternalPortType.Auxiliary, 7)]
        [XmlEnum("8007")]
        Auxilary7 = 8007,
        [VideoSourceType(InternalPortType.Auxiliary, 8)]
        [XmlEnum("8008")]
        Auxilary8 = 8008,
        [VideoSourceType(InternalPortType.Auxiliary, 9)]
        [XmlEnum("8009")]
        Auxilary9 = 8009,
        [VideoSourceType(InternalPortType.Auxiliary, 10)]
        [XmlEnum("8010")]
        Auxilary10 = 8010,
        [VideoSourceType(InternalPortType.Auxiliary, 11)]
        [XmlEnum("8011")]
        Auxilary11 = 8011,
        [VideoSourceType(InternalPortType.Auxiliary, 12)]
        [XmlEnum("8012")]
        Auxilary12 = 8012,
        [VideoSourceType(InternalPortType.Auxiliary, 13)]
        [XmlEnum("8013")]
        Auxilary13 = 8013,
        [VideoSourceType(InternalPortType.Auxiliary, 14)]
        [XmlEnum("8014")]
        Auxilary14 = 8014,
        [VideoSourceType(InternalPortType.Auxiliary, 15)]
        [XmlEnum("8015")]
        Auxilary15 = 8015,
        [VideoSourceType(InternalPortType.Auxiliary, 16)]
        [XmlEnum("8016")]
        Auxilary16 = 8016,
        [VideoSourceType(InternalPortType.Auxiliary, 17)]
        [XmlEnum("8017")]
        Auxilary17 = 8017,
        [VideoSourceType(InternalPortType.Auxiliary, 18)]
        [XmlEnum("8018")]
        Auxilary18 = 8018,
        [VideoSourceType(InternalPortType.Auxiliary, 19)]
        [XmlEnum("8019")]
        Auxilary19 = 8019,
        [VideoSourceType(InternalPortType.Auxiliary, 20)]
        [XmlEnum("8020")]
        Auxilary20 = 8020,
        [VideoSourceType(InternalPortType.Auxiliary, 21)]
        [XmlEnum("8021")]
        Auxilary21 = 8021,
        [VideoSourceType(InternalPortType.Auxiliary, 22)]
        [XmlEnum("8022")]
        Auxilary22 = 8022,
        [VideoSourceType(InternalPortType.Auxiliary, 23)]
        [XmlEnum("8023")]
        Auxilary23 = 8023,
        [VideoSourceType(InternalPortType.Auxiliary, 24)]
        [XmlEnum("8024")]
        Auxilary24 = 8024,

        [VideoSourceType(InternalPortType.MEOutput, 1)]
        [XmlEnum("10010")]
        ME1Prog = 10010,
        [VideoSourceType(InternalPortType.MEOutput, 1)]
        [XmlEnum("10011")]
        ME1Prev = 10011,
        [VideoSourceType(InternalPortType.MEOutput, 2)]
        [XmlEnum("10020")]
        ME2Prog = 10020,
        [VideoSourceType(InternalPortType.MEOutput, 2)]
        [XmlEnum("10021")]
        ME2Prev = 10021,
        [VideoSourceType(InternalPortType.MEOutput, 3)]
        [XmlEnum("10030")]
        ME3Prog = 10030,
        [VideoSourceType(InternalPortType.MEOutput, 3)]
        [XmlEnum("10031")]
        ME3Prev = 10031,
        [VideoSourceType(InternalPortType.MEOutput, 4)]
        [XmlEnum("10040")]
        ME4Prog = 10040,
        [VideoSourceType(InternalPortType.MEOutput, 4)]
        [XmlEnum("10041")]
        ME4Prev = 10041,
        
        [VideoSourceType(InternalPortType.External, 1)]
        [XmlEnum("11001")]
        Input1Direct = 11001,
    }
    
    public class VideoSourceTypeAttribute : Attribute
    {
        public InternalPortType PortType { get; }
        public int Me1Index { get; }
        public int Me2Index { get; }

        public VideoSourceTypeAttribute(InternalPortType portType, int me1Index, int me2Index = -1)
        {
            PortType = portType;
            Me1Index = me1Index;
            Me2Index = me2Index == -1 ? me1Index : me2Index;
        }
    }
}
