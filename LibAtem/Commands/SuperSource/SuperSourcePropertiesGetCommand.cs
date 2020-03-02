﻿using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("SSrc", CommandDirection.ToClient, 32), NoCommandId]
    public class SuperSourcePropertiesGetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum16]
        public VideoSource ArtFillInput { get; set; }
        [Serialize(2), Enum16]
        public VideoSource ArtKeyInput { get; set; }
        [Serialize(4), Enum8]
        public SuperSourceArtOption ArtOption { get; set; }
        [Serialize(5), Bool]
        public bool ArtPreMultiplied { get; set; }
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double ArtClip { get; set; }
        [Serialize(8), UInt16D(10, 0, 1000)]
        public double ArtGain { get; set; }
        [Serialize(10), Bool]
        public bool ArtInvertKey { get; set; }

        [Serialize(11), Bool]
        public bool BorderEnabled { get; set; }
        [Serialize(12), Enum8]
        public BorderBevel BorderBevel { get; set; }
        [Serialize(14), UInt16D(100, 0, 1600)]
        public double BorderOuterWidth { get; set; }
        [Serialize(16), UInt16D(100, 0, 1600)]
        public double BorderInnerWidth { get; set; }
        [Serialize(18), UInt8Range(0, 100)]
        public uint BorderOuterSoftness { get; set; }
        [Serialize(19), UInt8Range(0, 100)]
        public uint BorderInnerSoftness { get; set; }
        [Serialize(20), UInt8Range(0, 100)]
        public uint BorderBevelSoftness { get; set; }
        [Serialize(21), UInt8Range(0, 100)]
        public uint BorderBevelPosition { get; set; }
        [Serialize(22), UInt16D(10, 0, 3599)]
        public double BorderHue { get; set; }
        [Serialize(24), UInt16D(10, 0, 1000)]
        public double BorderSaturation { get; set; }
        [Serialize(26), UInt16D(10, 0, 1000)]
        public double BorderLuma { get; set; }
        [Serialize(28), UInt16D(10, 0, 3599)]
        public double BorderLightSourceDirection { get; set; }
        [Serialize(30), UInt8D(1, 0, 100)]
        public double BorderLightSourceAltitude { get; set; }
    }
}