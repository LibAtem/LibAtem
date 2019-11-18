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
            SizeX = 1 << 0,
            SizeY = 1 << 1,
            PositionX = 1 << 2,
            PositionY = 1 << 3,
            Rotation = 1 << 4,
            OuterWidth = 1 << 5,
            InnerWidth = 1 << 6,
            OuterSoftness = 1 << 7,
            InnerSoftness = 1 << 8,
            BevelSoftness = 1 << 9,
            BevelPosition = 1 << 10,
            BorderOpacity = 1 << 11,
            BorderHue = 1 << 12,
            BorderSaturation = 1 << 13,
            BorderLuma = 1 << 14,
            LightSourceDirection = 1 << 15,
            LightSourceAltitude = 1 << 16,
            MaskTop = 1 << 17,
            MaskBottom = 1 << 18,
            MaskLeft = 1 << 19,
            MaskRight = 1 << 20,
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

        [Serialize(8), UInt32D(1000, 0, (32768 * 1000) - 1)]
        public double SizeX { get; set; }
        [Serialize(12), UInt32D(1000, 0, (32768 * 1000) - 1)]
        public double SizeY { get; set; }

        [Serialize(16), Int32D(1000, -32768 * 1000, 32768 * 1000)]
        public double PositionX { get; set; }
        [Serialize(20), Int32D(1000, -32768 * 1000, 32768 * 1000)]
        public double PositionY { get; set; }

        [Serialize(24), Int32D(10, -327680, 327680)]
        public double Rotation { get; set; }

        [Serialize(28), UInt16D(100, 0, 65535)]
        public double OuterWidth { get; set; }
        [Serialize(30), UInt16D(100, 0, 65535)]
        public double InnerWidth { get; set; }
        [Serialize(32), UInt8Range(0, 254)]
        public uint OuterSoftness { get; set; }
        [Serialize(33), UInt8Range(0, 254)]
        public uint InnerSoftness { get; set; }
        [Serialize(34), UInt8Range(0, 254)]
        public uint BevelSoftness { get; set; }
        [Serialize(35), UInt8Range(0, 254)]
        public uint BevelPosition { get; set; }

        [Serialize(36), UInt8Range(0, 254)]
        public uint BorderOpacity { get; set; }
        [Serialize(38), UInt16D(10, 0, 65535)]
        public double BorderHue { get; set; }
        [Serialize(40), UInt16D(10, 0, 65535)]
        public double BorderSaturation { get; set; }
        [Serialize(42), UInt16D(10, 0, 65535)]
        public double BorderLuma { get; set; }

        [Serialize(44), UInt16D(10, 0, 65535)]
        public double LightSourceDirection { get; set; }
        [Serialize(46), UInt8Range(0, 254)]
        public uint LightSourceAltitude { get; set; }

        // TODO - MaskEnabled?

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