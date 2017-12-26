using System;
using System.Xml.Serialization;
using LibAtem.Util;

namespace LibAtem.Common
{
    public enum VideoModeStandard
    {
        SDISD,
        SDIHD,
        SDI3G,
        SDI6G,
        SDI12G,
    }

    public enum VideoMode
    {
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDISD)]
        [VideoModeMaxClipLength(3600)]
        [XmlEnum("525i5994 NTSC")]
        N525i5994NTSC = 0,
        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDISD)]
        [VideoModeMaxClipLength(3600)]
        [XmlEnum("625i50 PAL")]
        P625i50PAL = 1,
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDISD)]
        [VideoModeMaxClipLength(3600)]
        [XmlEnum("525i5994 16:9")]
        N525i5994169 = 2,
        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDISD)]
        [VideoModeMaxClipLength(3600)]
        [XmlEnum("625i50 16:9")]
        P625i50169 = 3,

        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeMaxClipLength(1600)]
        [XmlEnum("720p50")]
        P720p50 = 4,
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeMaxClipLength(1600)]
        [XmlEnum("720p5994")]
        N720p5994 = 5,
        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeMaxClipLength(720)]
        [XmlEnum("1080i50")]
        P1080i50 = 6,
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeMaxClipLength(720)]
        [XmlEnum("1080i5994")]
        N1080i5994 = 7,
        [VideoModeRate(23.98), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeMaxClipLength(720)]
        [XmlEnum("1080p2398")]
        N1080p2398 = 8,
        [VideoModeRate(24), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeMaxClipLength(720)]
        [XmlEnum("1080p24")]
        N1080p24 = 9,
        [VideoModeRate(25), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeMaxClipLength(720)]
        [XmlEnum("1080p25")]
        P1080p25 = 10,
        [VideoModeRate(29.97), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeMaxClipLength(720)]
        [XmlEnum("1080p2997")]
        N1080p2997 = 11,

        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDI3G)]
        [VideoModeMaxClipLength(720)]
        [XmlEnum("1080p50")]
        P1080p50 = 12,
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDI3G)]
        [VideoModeMaxClipLength(720)]
        [XmlEnum("1080p5994")]
        N1080p5994 = 13,

        [VideoModeRate(23.98), VideoModeStandard(VideoModeStandard.SDI6G)]
        [VideoModeMaxClipLength(180)]
        [XmlEnum("4KHDp2398")]
        N4KHDp2398 = 14,
        [VideoModeRate(24), VideoModeStandard(VideoModeStandard.SDI6G)]
        [VideoModeMaxClipLength(180)]
        [XmlEnum("4KHDp24")]
        N4KHDp24 = 15,
        [VideoModeRate(25), VideoModeStandard(VideoModeStandard.SDI6G)]
        [VideoModeMaxClipLength(180)]
        [XmlEnum("4KHDp25")]
        P4KHDp25 = 16,
        [VideoModeRate(29.97), VideoModeStandard(VideoModeStandard.SDI6G)]
        [VideoModeMaxClipLength(180)]
        [XmlEnum("4KHDp2997")]
        N4KHDp2997 = 17,
        
        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDI12G)]
        [VideoModeMaxClipLength(180)]
        [XmlEnum("4KHDp50")]
        P4KHDp5000 = 18,
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDI12G)]
        [VideoModeMaxClipLength(180)]
        [XmlEnum("4KHDp5994")]
        N4KHDp5994 = 19,
    }

    public class VideoModeRateAttribute : Attribute
    {
        public double Rate { get; }

        public VideoModeRateAttribute(double rate)
        {
            Rate = rate;
        }
    }

    public class VideoModeStandardAttribute : Attribute
    {
        public VideoModeStandard Standard { get; }

        public VideoModeStandardAttribute(VideoModeStandard standard)
        {
            Standard = standard;
        }
    }

    public class VideoModeMaxClipLengthAttribute : Attribute
    {
        public uint MaxLength { get; }

        public VideoModeMaxClipLengthAttribute(uint maxLength)
        {
            MaxLength = maxLength;
        }
    }

    public static class VideoModeExtensions
    {
        public static uint MaxClipLength(this VideoMode mode)
        {
            return mode.GetAttribute<VideoMode, VideoModeMaxClipLengthAttribute>().MaxLength;
        }

        public static VideoModeStandard GetStandard(this VideoMode mode)
        {
            return mode.GetAttribute<VideoMode, VideoModeStandardAttribute>().Standard;
        }
    }
}