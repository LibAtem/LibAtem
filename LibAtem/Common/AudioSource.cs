using System;
using System.Xml.Serialization;

namespace LibAtem.Common
{
    public enum AudioSource
    {
        [XmlEnum("1")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input1 = 1,
        [XmlEnum("2")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input2 = 2,
        [XmlEnum("3")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input3 = 3,
        [XmlEnum("4")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input4 = 4,
        [XmlEnum("5")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input5 = 5,
        [XmlEnum("6")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input6 = 6,
        [XmlEnum("7")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input7 = 7,
        [XmlEnum("8")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input8 = 8,
        [XmlEnum("9")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input9 = 9,
        [XmlEnum("10")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input10 = 10,
        [XmlEnum("11")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input11 = 11,
        [XmlEnum("12")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input12 = 12,
        [XmlEnum("13")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input13 = 13,
        [XmlEnum("14")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input14 = 14,
        [XmlEnum("15")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input15 = 15,
        [XmlEnum("16")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input16 = 16,
        [XmlEnum("17")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input17 = 17,
        [XmlEnum("18")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input18 = 18,
        [XmlEnum("19")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input19 = 19,
        [XmlEnum("20")]
        [AudioSourceType(AudioSourceType.ExternalVideo)]
        Input20 = 20,

        [XmlEnum("1001")]
        [AudioSourceType(AudioSourceType.ExternalAudio)]
        [AudioPortType(ExternalPortType.XLR)]
        XLR = 1001,
        [XmlEnum("1101")]
        [AudioSourceType(AudioSourceType.ExternalAudio)]
        [AudioPortType(ExternalPortType.AESEBU)]
        AESEBU = 1101,
        [XmlEnum("1201")]
        [AudioSourceType(AudioSourceType.ExternalAudio)]
        [AudioPortType(ExternalPortType.RCA)]
        RCA = 1201,

        [XmlEnum("1301")]
        [AudioSourceType(AudioSourceType.ExternalAudio)]
        [AudioPortType(ExternalPortType.Internal)]
        Mic1 = 1301,
        [XmlEnum("1302")]
        [AudioSourceType(AudioSourceType.ExternalAudio)]
        [AudioPortType(ExternalPortType.Internal)]
        Mic2 = 1302,

        [XmlEnum("2001")]
        [AudioSourceType(AudioSourceType.MediaPlayer)]
        [AudioPortType(ExternalPortType.Internal)]
        MP1 = 2001,
        [XmlEnum("2002")]
        [AudioSourceType(AudioSourceType.MediaPlayer)]
        [AudioPortType(ExternalPortType.Internal)]
        MP2 = 2002,
        [XmlEnum("2003")]
        [AudioSourceType(AudioSourceType.MediaPlayer)]
        [AudioPortType(ExternalPortType.Internal)]
        MP3 = 2003,
        [XmlEnum("2004")]
        [AudioSourceType(AudioSourceType.MediaPlayer)]
        [AudioPortType(ExternalPortType.Internal)]
        MP4 = 2004,
    }

    public enum AudioSourceType
    {
        ExternalVideo = 0,
        MediaPlayer = 1,
        ExternalAudio = 2,
    }

    public class AudioSourceTypeAttribute : Attribute
    {
        public AudioSourceType Type { get; }

        public AudioSourceTypeAttribute(AudioSourceType type)
        {
            Type = type;
        }
    }

    public class AudioPortTypeAttribute : Attribute
    {
        public ExternalPortType Type { get; }

        public AudioPortTypeAttribute(ExternalPortType type)
        {
            Type = type;
        }
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