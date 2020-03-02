using System;
using System.Xml.Serialization;
using LibAtem.Util;

namespace LibAtem.Common
{
    public enum VideoModeStandard
    {
        SDISD,
        SDIHD,
        SDIHDProgressive,
        HDMI,
        SDI3G,
        SDI6G,
        SDI12G,
        SDI24G,
    }

    public enum VideoModeResolution
    {
        [Size(640, 480)]
        NTSC,
        [Size(720, 576)]
        PAL,
        [Size(1280, 720)]
        _720,
        [Size(1920, 1080)]
        _1080,
        [Size(3840, 2160)]
        _4K,
        [Size(7680, 4260)]
        _8K,
    }

    public enum VideoMode
    {
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDISD), VideoModeMultiviewerMode(N1080i5994)]
        [VideoModeResolution(VideoModeResolution.NTSC)]
        [XmlEnum("525i5994 NTSC")]
        N525i5994NTSC = 0,
        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDISD), VideoModeMultiviewerMode(P1080i50)]
        [VideoModeResolution(VideoModeResolution.PAL)]
        [XmlEnum("625i50 PAL")]
        P625i50PAL = 1,
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDISD), VideoModeMultiviewerMode(N1080i5994)]
        [VideoModeResolution(VideoModeResolution.NTSC)]
        [XmlEnum("525i5994 16:9")]
        N525i5994169 = 2,
        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDISD), VideoModeMultiviewerMode(P1080i50)]
        [VideoModeResolution(VideoModeResolution.PAL)]
        [XmlEnum("625i50 16:9")]
        P625i50169 = 3,

        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeResolution(VideoModeResolution._720)]
        [XmlEnum("720p50")]
        P720p50 = 4,
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeResolution(VideoModeResolution._720)]
        [XmlEnum("720p5994")]
        N720p5994 = 5,
        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeResolution(VideoModeResolution._1080)]
        [XmlEnum("1080i50")]
        P1080i50 = 6,
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDIHD)]
        [VideoModeResolution(VideoModeResolution._1080)]
        [XmlEnum("1080i5994")]
        N1080i5994 = 7,

        [VideoModeRate(23.98), VideoModeStandard(VideoModeStandard.SDIHDProgressive)]
        [VideoModeResolution(VideoModeResolution._1080)]
        [XmlEnum("1080p2398")]
        N1080p2398 = 8,
        [VideoModeRate(24), VideoModeStandard(VideoModeStandard.SDIHDProgressive)]
        [VideoModeResolution(VideoModeResolution._1080)]
        [XmlEnum("1080p24")]
        N1080p24 = 9,
        [VideoModeRate(25), VideoModeStandard(VideoModeStandard.SDIHDProgressive), VideoModeMultiviewerMode(P1080p25, P1080i50)]
        [VideoModeResolution(VideoModeResolution._1080)]
        [XmlEnum("1080p25")]
        P1080p25 = 10,
        [VideoModeRate(29.97), VideoModeStandard(VideoModeStandard.SDIHDProgressive), VideoModeMultiviewerMode(N1080p2997, N1080i5994)]
        [VideoModeResolution(VideoModeResolution._1080)]
        [XmlEnum("1080p2997")]
        N1080p2997 = 11,

        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDI3G), VideoModeMultiviewerMode(P1080p50, P1080i50)]
        [VideoModeResolution(VideoModeResolution._1080)]
        [XmlEnum("1080p50")]
        P1080p50 = 12,
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDI3G), VideoModeMultiviewerMode(N1080p5994, N1080i5994)]
        [VideoModeResolution(VideoModeResolution._1080)]
        [XmlEnum("1080p5994")]
        N1080p5994 = 13,

        [VideoModeRate(23.98), VideoModeStandard(VideoModeStandard.SDI6G), VideoModeMultiviewerMode(N1080p2398)]
        [VideoModeResolution(VideoModeResolution._4K)]
        [XmlEnum("4KHDp2398")]
        N4KHDp2398 = 14,
        [VideoModeRate(24), VideoModeStandard(VideoModeStandard.SDI6G), VideoModeMultiviewerMode(N1080p24)]
        [VideoModeResolution(VideoModeResolution._4K)]
        [XmlEnum("4KHDp24")]
        N4KHDp24 = 15,
        [VideoModeRate(25), VideoModeStandard(VideoModeStandard.SDI6G), VideoModeMultiviewerMode(P1080i50)]
        [VideoModeResolution(VideoModeResolution._4K)]
        [XmlEnum("4KHDp25")]
        P4KHDp25 = 16,
        [VideoModeRate(29.97), VideoModeStandard(VideoModeStandard.SDI6G), VideoModeMultiviewerMode(N1080i5994)]
        [VideoModeResolution(VideoModeResolution._4K)]
        [XmlEnum("4KHDp2997")]
        N4KHDp2997 = 17,

        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDI12G), VideoModeMultiviewerMode(P1080i50)]
        [VideoModeResolution(VideoModeResolution._4K)]
        [XmlEnum("4KHDp50")]
        P4KHDp5000 = 18,
        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDI12G), VideoModeMultiviewerMode(N1080i5994)]
        [VideoModeResolution(VideoModeResolution._4K)]
        [XmlEnum("4KHDp5994")]
        N4KHDp5994 = 19,

        [VideoModeRate(23.98), VideoModeStandard(VideoModeStandard.SDI24G)]
        [VideoModeResolution(VideoModeResolution._8K)]
        [XmlEnum("8KHDp2398")]
        N8KHDp2398 = 20, // TODO - verify

        [VideoModeRate(24), VideoModeStandard(VideoModeStandard.SDI24G)]
        [VideoModeResolution(VideoModeResolution._8K)]
        [XmlEnum("8KHDp24")]
        N8KHDp24 = 21, // TODO - verify

        [VideoModeRate(25), VideoModeStandard(VideoModeStandard.SDI24G)]
        [VideoModeResolution(VideoModeResolution._8K)]
        [XmlEnum("8KHDp25")]
        P8KHDp25 = 22, // TODO - verify

        [VideoModeRate(29.97), VideoModeStandard(VideoModeStandard.SDI24G)]
        [VideoModeResolution(VideoModeResolution._8K)]
        [XmlEnum("8KHDp2997")]
        N8KHDp2997 = 23, // TODO - verify

        [VideoModeRate(50), VideoModeStandard(VideoModeStandard.SDI24G)]
        [VideoModeResolution(VideoModeResolution._8K)]
        [XmlEnum("8KHDp50")]
        P8KHDp50 = 24, // TODO - verify

        [VideoModeRate(59.94), VideoModeStandard(VideoModeStandard.SDI24G)]
        [VideoModeResolution(VideoModeResolution._8K)]
        [XmlEnum("8KHDp5994")]
        N8KHDp5994 = 25, // TODO - verify

        [VideoModeRate(30), VideoModeStandard(VideoModeStandard.HDMI), VideoModeMultiviewerMode(N1080p30)]
        [VideoModeResolution(VideoModeResolution._1080)]
        [XmlEnum("1080p2997")]
        N1080p30= 26, // TODO - verify
        [VideoModeRate(60), VideoModeStandard(VideoModeStandard.HDMI), VideoModeMultiviewerMode(N1080p60)]
        [VideoModeResolution(VideoModeResolution._1080)]
        [XmlEnum("1080p5994")]
        N1080p60 = 27, // TODO - verify
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

    public class VideoModeMultiviewerModeAttribute : Attribute
    {
        public VideoModeMultiviewerModeAttribute(VideoMode mode)
            : this(mode, mode)
        {
        }

        public VideoModeMultiviewerModeAttribute(VideoMode mode, VideoMode modeNon3G)
        {
            Mode = mode;
            ModeNon3G = modeNon3G;
        }

        public VideoMode Mode { get; }
        public VideoMode ModeNon3G { get; }
    }

    public class VideoModeResolutionAttribute : Attribute
    {
        public VideoModeResolution Resolution { get; }

        public VideoModeResolutionAttribute(VideoModeResolution res)
        {
            Resolution = res;
        }
    }

    public class SizeAttribute : Attribute
    {
        public uint Width { get; }
        public uint Height { get; }

        public Tuple<uint, uint> Size => Tuple.Create(Width, Height);

        public SizeAttribute(uint width, uint height)
        {
            Width = width;
            Height = height;
        }
    }

    public static class VideoModeExtensions
    {
        public static VideoModeResolution GetResolution(this VideoMode mode)
        {
            return mode.GetAttribute<VideoMode, VideoModeResolutionAttribute>().Resolution;
        }

        public static Tuple<uint, uint> GetSize(this VideoModeResolution res)
        {
            return res.GetAttribute<VideoModeResolution, SizeAttribute>().Size;
        }

        public static int GetByteCount(this VideoModeResolution res)
        {
            var size = res.GetAttribute<VideoModeResolution, SizeAttribute>().Size;
            return (int)(size.Item1 * size.Item2 * 4);
        }

        public static VideoModeStandard GetStandard(this VideoMode mode)
        {
            return mode.GetAttribute<VideoMode, VideoModeStandardAttribute>().Standard;
        }

        public static double GetRate(this VideoMode mode)
        {
            return mode.GetAttribute<VideoMode, VideoModeRateAttribute>().Rate;
        }
    }
}