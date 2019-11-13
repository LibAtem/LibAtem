using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("SSBd", ProtocolVersion.V8_0, 24)]
    public class SuperSourceBorderGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public SuperSourceId SSrcId { get; set; }

        [Serialize(1), Bool]
        public bool BorderEnabled { get; set; }
        [Serialize(2), Enum8]
        public BorderBevel BorderBevel { get; set; }
        [Serialize(4), UInt16D(100, 0, 1600)]
        public double BorderWidthOut { get; set; }
        [Serialize(6), UInt16D(100, 0, 1600)]
        public double BorderWidthIn { get; set; }
        [Serialize(8), UInt8Range(0, 100)]
        public uint BorderSoftnessOut { get; set; }
        [Serialize(9), UInt8Range(0, 100)]
        public uint BorderSoftnessIn { get; set; }
        [Serialize(10), UInt8Range(0, 100)]
        public uint BorderBevelSoftness { get; set; }
        [Serialize(11), UInt8Range(0, 100)]
        public uint BorderBevelPosition { get; set; }
        [Serialize(12), UInt16D(10, 0, 3599)]
        public double BorderHue { get; set; }
        [Serialize(14), UInt16D(10, 0, 1000)]
        public double BorderSaturation { get; set; }
        [Serialize(16), UInt16D(10, 0, 1000)]
        public double BorderLuma { get; set; }
        [Serialize(18), UInt16D(10, 0, 3599)]
        public double BorderLightSourceDirection { get; set; }
        [Serialize(20), UInt8D(1, 0, 100)]
        public double BorderLightSourceAltitude { get; set; }
    }
}