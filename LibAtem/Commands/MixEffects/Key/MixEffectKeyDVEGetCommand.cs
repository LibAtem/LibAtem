using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeDV", 60)]
    public class MixEffectKeyDVEGetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serialize(1), UInt8]
        public uint KeyerIndex { get; set; }

        [Serialize(4), Int32D(1000, -100, 100)] // TODO - check range
        public double SizeX { get; set; }
        [Serialize(8), Int32D(1000, -100, 100)] // TODO - check range
        public double SizeY { get; set; }
        [Serialize(12), Int32D(1000, -1000, 1000)] // TODO - check range
        public double PositionX { get; set; }
        [Serialize(16), Int32D(1000, -1000, 1000)] // TODO - check range
        public double PositionY { get; set; }
        [Serialize(20), Int32D(1000, -1000, 1000)] // TODO - check range
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
        [Serialize(32), UInt8D(100, 0, 100)]
        public double OuterSoftness { get; set; }
        [Serialize(33), UInt8D(100, 0, 100)]
        public double InnerSoftness { get; set; }
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

//        public void Serialize(CommandBuilder cmd)
//        {
//            cmd.AddByte(0x00, 0x2C, 0x00, 0x60, 0x72, 0x50, 0x6E, 0x49, 0x6F, 0x43, 0xD2, 0x07, 0x20, 0x72, 0x6F, 0x6C,
//                0x00, 0x00, 0x00, 0x32, 0x60, 0x00, 0x2B, 0xC8, 0x08, 0xE7, 0x27, 0x60, 0x00, 0xA0, 0x6F, 0x43, 0x6C,
//                0x32, 0x01, 0x00, 0x01, 0x00, 0x00, 0x01, 0x00, 0x03, 0x01, 0x03, 0x2C, 0x00, 0x9B, 0x60, 0x6E, 0x49,
//                0x72, 0x50, 0xC2, 0x0B, 0x65, 0x4D, 0x64, 0x69, 0x61, 0x20);
//        }
//
//        public void Deserialize(ParsedCommand cmd)
//        {
//            // TODO
//            cmd.Skip(60);
//        }
    }
}