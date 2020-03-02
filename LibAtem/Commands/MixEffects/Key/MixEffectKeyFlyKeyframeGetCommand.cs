using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KKFP", CommandDirection.ToClient, 52)]
    public class MixEffectKeyFlyKeyframeGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        [CommandId]
        [Serialize(2), Enum8]
        public FlyKeyKeyFrameId KeyFrame { get; set; }

        [Serialize(4), UInt32D(1000, 0, (32768 * 1000) - 1)]
        public double SizeX { get; set; }
        [Serialize(8), UInt32D(1000, 0, (32768 * 1000) - 1)]
        public double SizeY { get; set; }

        [Serialize(12), Int32D(1000, -32768 * 1000, 32768 * 1000)]
        public double PositionX { get; set; }
        [Serialize(16), Int32D(1000, -32768 * 1000, 32768 * 1000)]
        public double PositionY { get; set; }

        [Serialize(20), Int32D(10, -327680, 327680)]
        public double Rotation { get; set; }

        [Serialize(24), UInt16D(100, 0, 65535)]
        public double OuterWidth { get; set; }
        [Serialize(26), UInt16D(100, 0, 65535)]
        public double InnerWidth { get; set; }
        [Serialize(28), UInt8Range(0, 254)]
        public uint OuterSoftness { get; set; }
        [Serialize(29), UInt8Range(0, 254)]
        public uint InnerSoftness { get; set; }
        [Serialize(30), UInt8Range(0, 254)]
        public uint BevelSoftness { get; set; }
        [Serialize(31), UInt8Range(0, 254)]
        public uint BevelPosition { get; set; }

        [Serialize(32), UInt8Range(0, 255)]
        public uint BorderOpacity { get; set; }
        [Serialize(34), UInt16D(10, 0, 65535)]
        public double BorderHue { get; set; }
        [Serialize(36), UInt16D(10, 0, 65535)]
        public double BorderSaturation { get; set; }
        [Serialize(38), UInt16D(10, 0, 65535)]
        public double BorderLuma { get; set; }

        [Serialize(40), UInt16D(10, 0, 65535)]
        public double LightSourceDirection { get; set; }
        [Serialize(42), UInt8Range(0, 254)]
        public uint LightSourceAltitude { get; set; }
        
        [Serialize(44), Int16D(1000, -9000, 9000)]
        public double MaskTop { get; set; }
        [Serialize(46), Int16D(1000, -9000, 9000)]
        public double MaskBottom { get; set; }
        [Serialize(48), Int16D(1000, -16000, 16000)]
        public double MaskLeft { get; set; }
        [Serialize(50), Int16D(1000, -16000, 16000)]
        public double MaskRight { get; set; }
    }
}