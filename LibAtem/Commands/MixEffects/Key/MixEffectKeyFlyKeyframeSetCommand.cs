using LibAtem.Common;
using LibAtem.Serialization;
using System;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKFP", 56)]
    public class MixEffectKeyFlyKeyframeSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            XSize = 1 << 0,
            YSize = 1 << 1,
            XPosition = 1 << 2,
            YPosition = 1 << 3,
            Rotation = 1 << 4,
            BorderEnabled = 1 << 5, // TODO check this
            ShadowEnabled = 1 << 6, // TODO check this
            BorderBevel = 1 << 7,
            BorderOuterWidth = 1 << 8,
            BorderInnerWidth = 1 << 9,
            BorderOuterSoftness = 1 << 10,
            BorderInnerSoftness = 1 << 11,
            BorderBevelSoftness = 1 << 12,
            BorderBevelPosition = 1 << 13,
            BorderOpacity = 1 << 14,
            BorderHue = 1 << 15,
            BorderSaturation = 1 << 16,
            BorderLuma = 1 << 17,
            LightSourceDirection = 1 << 18,
            LightSourceAltitude = 1 << 19,
            MaskEnabled = 1 << 20, // TODO check this
            MaskTop = 1 << 21,
            MaskBottom = 1 << 22,
            MaskLeft = 1 << 23,
            MaskRight = 1 << 24,
        }

        [Serialize(0), Enum32]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(4), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(5), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        [CommandId]
        [Serialize(6), Enum8]
        public FlyKeyKeyFrameId KeyFrame { get; set; }

        [Serialize(8), UInt32D(1000, 0, 32767900)]
        public double XSize { get; set; }
        [Serialize(12), UInt32D(1000, 0, 32767900)]
        public double YSize { get; set; }

        [Serialize(16), Int32D(1000, -32768 * 1000, 32768 * 1000)]
        public double XPosition { get; set; }
        [Serialize(20), Int32D(1000, -32768 * 1000, 32768 * 1000)]
        public double YPosition { get; set; }

        [Serialize(24), Int32D(10, -327680, 327680)]
        public double Rotation { get; set; }

        [Serialize(28), UInt16D(100, 0, 1600)]
        public double OuterWidth { get; set; }
        [Serialize(30), UInt16D(100, 0, 1600)]
        public double InnerWidth { get; set; }
        [Serialize(32), UInt8Range(0, 100)]
        public uint OuterSoftness { get; set; }
        [Serialize(33), UInt8Range(0, 100)]
        public uint InnerSoftness { get; set; }
        [Serialize(34), UInt8Range(0, 100)]
        public uint BevelSoftness { get; set; }
        [Serialize(35), UInt8Range(0, 100)]
        public uint BevelPosition { get; set; }

        [Serialize(36), UInt8Range(0, 100)]
        public uint BorderOpacity { get; set; }
        [Serialize(38), UInt16D(10, 0, 3599)]
        public double BorderHue { get; set; }
        [Serialize(40), UInt16D(10, 0, 1000)]
        public double BorderSaturation { get; set; }
        [Serialize(42), UInt16D(10, 0, 1000)]
        public double BorderLuma { get; set; }

        [Serialize(44), UInt16D(10, 0, 3590)]
        public double LightSourceDirection { get; set; }
        [Serialize(46), UInt8Range(10, 100)]
        public uint LightSourceAltitude { get; set; }

        [Serialize(47), Bool(7)]
        public bool MaskEnabled { get; set; }
        [Serialize(48), Int16D(1000, -9000, 9000)]
        public double MaskTop { get; set; }
        [Serialize(50), Int16D(1000, -9000, 9000)]
        public double MaskBottom { get; set; }
        [Serialize(52), Int16D(1000, -16000, 16000)]
        public double MaskLeft { get; set; }
        [Serialize(54), Int16D(1000, -16000, 16000)]
        public double MaskRight { get; set; }
    }
}