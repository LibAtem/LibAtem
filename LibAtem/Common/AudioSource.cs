using System;
using System.Xml.Serialization;

namespace LibAtem.Common
{
    public enum AudioSource
    {
        [XmlEnum("1")]
        Input1 = 1,
        [XmlEnum("2")]
        Input2 = 2,
        [XmlEnum("3")]
        Input3 = 3,
        [XmlEnum("4")]
        Input4 = 4,
        [XmlEnum("5")]
        Input5 = 5,
        [XmlEnum("6")]
        Input6 = 6,
        [XmlEnum("7")]
        Input7 = 7,
        [XmlEnum("8")]
        Input8 = 8,
        [XmlEnum("9")]
        Input9 = 9,
        [XmlEnum("10")]
        Input10 = 10,
        [XmlEnum("11")]
        Input11 = 11,
        [XmlEnum("12")]
        Input12 = 12,
        [XmlEnum("13")]
        Input13 = 13,
        [XmlEnum("14")]
        Input14 = 14,
        [XmlEnum("15")]
        Input15 = 15,
        [XmlEnum("16")]
        Input16 = 16,
        [XmlEnum("17")]
        Input17 = 17,
        [XmlEnum("18")]
        Input18 = 18,
        [XmlEnum("19")]
        Input19 = 19,
        [XmlEnum("20")]
        Input20 = 20,

        [XmlEnum("1001")]
        XLR = 1001,
        [XmlEnum("1101")]
        AESEBU = 1101,
        [XmlEnum("1201")]
        RCA = 1201,

        [XmlEnum("1301")]
        Mic1 = 1301,
        [XmlEnum("1302")]
        Mic2 = 1302,

        [XmlEnum("2001")]
        MP1 = 2001,
        [XmlEnum("2002")]
        MP2 = 2002,
        [XmlEnum("2003")]
        MP3 = 2003,
        [XmlEnum("2004")]
        MP4 = 2004,
    }

    public enum AudioSourceType
    {
        ExternalVideo = 0,
        MediaPlayer = 1,
        ExternalAudio = 2,
    }

    public static class AudioSourceExtensions
    {
        public static VideoSource? GetVideoSource(this AudioSource src)
        {
            if ((int)src <= 20)
                return (VideoSource)src;
            
            switch (src)
            {
                case AudioSource.MP1:
                   return VideoSource.MediaPlayer1;
                case AudioSource.MP2:
                    return VideoSource.MediaPlayer2;
                case AudioSource.MP3:
                    return VideoSource.MediaPlayer3;
                case AudioSource.MP4:
                    return VideoSource.MediaPlayer4;
                default:
                    return null;
            }
        }
        public static AudioSource? GetAudioSource(this VideoSource src)
        {
            if ((int)src <= 20 && (int)src >= 1)
                return (AudioSource)src;

            switch (src)
            {
                case VideoSource.MediaPlayer1:
                    return AudioSource.MP1;
                case VideoSource.MediaPlayer2:
                    return AudioSource.MP2;
                case VideoSource.MediaPlayer3:
                    return AudioSource.MP3;
                case VideoSource.MediaPlayer4:
                    return AudioSource.MP4;
                default:
                    return null;
            }
        }
    }
}