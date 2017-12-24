using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeDV", 60)]
    public class MixEffectKeyDVEGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }

        [Serialize(4), UInt32D(1000, 0, 99990)]
        public double SizeX { get; set; }
        [Serialize(8), UInt32D(1000, 0, 99990)]
        public double SizeY { get; set; }
        [Serialize(12), Int32D(1000, -1000 * 1000, 1000 * 1000)]
        public double PositionX { get; set; }
        [Serialize(16), Int32D(1000, -1000 * 1000, 1000 * 1000)]
        public double PositionY { get; set; }
        [Serialize(20), Int32D(10, -332230, 332230)]
        public double Rotation { get; set; }

        [Serialize(24), Bool]
        public bool BorderEnabled { get; set; }
        [Serialize(25), Bool]
        public bool BorderShadow { get; set; }
        [Serialize(26), Enum8]
        public BorderBevel BorderBevel { get; set; }
        [Serialize(28), UInt16D(100, 0, 1600)]
        public double OuterWidth { get; set; }
        [Serialize(30), UInt16D(100, 0, 1600)]
        public double InnerWidth { get; set; }
        [Serialize(32), UInt8Range(0, 100)]
        public uint OuterSoftness { get; set; }
        [Serialize(33), UInt8Range(0, 100)]
        public uint InnerSoftness { get; set; }
        [Serialize(34), UInt8D(100, 0, 100)]
        public double BevelSoftness { get; set; }
        [Serialize(35), UInt8D(100, 0, 100)]
        public double BevelPosition { get; set; }

        [Serialize(36), UInt8D(100, 0, 100)]
        public double BorderOpacity { get; set; }
        [Serialize(38), UInt16D(1000, 0, 3599)]
        public double BorderHue { get; set; }
        [Serialize(40), UInt16D(1000, 0, 1000)]
        public double BorderSaturation { get; set; }
        [Serialize(42), UInt16D(1000, 0, 1000)]
        public double BorderLuma { get; set; }

        [Serialize(44), UInt16D(10, 0, 3590)]
        public double LightSourceDirection { get; set; }
        [Serialize(46), UInt8D(1, 10, 100)]
        public double LightSourceAltitude { get; set; }

        [Serialize(47), Bool]
        public bool MaskEnabled { get; set; }
        [Serialize(48), Int16D(1000, -9000, 9000)]
        public double MaskTop { get; set; }
        [Serialize(50), Int16D(1000, -9000, 9000)]
        public double MaskBottom { get; set; }
        [Serialize(52), Int16D(1000, -16000, 16000)]
        public double MaskLeft { get; set; }
        [Serialize(54), Int16D(1000, -16000, 16000)]
        public double MaskRight { get; set; }

        [Serialize(56), UInt8Range(1, 250)]
        public uint Rate { get; set; }
    }
}