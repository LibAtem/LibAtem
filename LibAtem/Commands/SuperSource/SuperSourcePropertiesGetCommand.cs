using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("SSrc", 32)]
    public class SuperSourcePropertiesGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum16]
        public VideoSource ArtFillInput { get; set; }
        [Serializable(2), Enum16]
        public VideoSource ArtKeyInput { get; set; }
        [Serializable(4), Enum8]
        public SuperSourceArtOption ArtOption { get; set; }
        [Serializable(5), Bool]
        public bool ArtPreMultiplied { get; set; }
        [Serializable(6), UInt16D(1000, 0, 1000)]
        public double ArtClip { get; set; }
        [Serializable(8), UInt16D(1000, 0, 1000)]
        public double ArtGain { get; set; }
        [Serializable(10), Bool]
        public bool ArtInvertKey { get; set; }

        [Serializable(11), Bool]
        public bool BorderEnabled { get; set; }
        [Serializable(12), Enum8]
        public BorderBevel BorderBevel { get; set; }
        [Serializable(14), UInt16D(100, 0, 1600)]
        public double BorderWidthOut { get; set; }
        [Serializable(16), UInt16D(100, 0, 1600)]
        public double BorderWidthIn { get; set; }
        [Serializable(18), UInt8D(100, 0, 100)]
        public double BorderSoftnessOut { get; set; }
        [Serializable(19), UInt8D(100, 0, 100)]
        public double BorderSoftnessIn { get; set; }
        [Serializable(20), UInt8D(100, 0, 100)]
        public double BorderBevelSoftness { get; set; }
        [Serializable(21), UInt8D(100, 0, 100)]
        public double BorderBevelPosition { get; set; }
        [Serializable(22), UInt16D(10, 0, 3599)]
        public double BorderHue { get; set; }
        [Serializable(24), UInt16D(10, 0, 1000)]
        public double BorderSaturation { get; set; }
        [Serializable(26), UInt16D(10, 0, 1000)]
        public double BorderLuma { get; set; }
        [Serializable(28), UInt16D(10, 0, 3590)]
        public double BorderLightSourceDirection { get; set; }
        [Serializable(30), UInt8D(1, 0, 100)]
        public double BorderLightSourceAltitude { get; set; }
    }
}