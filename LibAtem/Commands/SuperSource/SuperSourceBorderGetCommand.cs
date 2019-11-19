using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("SSBd", CommandDirection.ToClient, ProtocolVersion.V8_0, 24)]
    public class SuperSourceBorderGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public SuperSourceId SSrcId { get; set; }

        [Serialize(1), Bool]
        public bool Enabled { get; set; }
        [Serialize(2), Enum8]
        public BorderBevel Bevel { get; set; }
        [Serialize(4), UInt16D(100, 0, 1600)]
        public double OuterWidth { get; set; }
        [Serialize(6), UInt16D(100, 0, 1600)]
        public double InnerWidth { get; set; }
        [Serialize(8), UInt8Range(0, 100)]
        public uint OuterSoftness { get; set; }
        [Serialize(9), UInt8Range(0, 100)]
        public uint InnerSoftness { get; set; }
        [Serialize(10), UInt8Range(0, 100)]
        public uint BevelSoftness { get; set; }
        [Serialize(11), UInt8Range(0, 100)]
        public uint BevelPosition { get; set; }
        [Serialize(12), UInt16D(10, 0, 3599)]
        public double Hue { get; set; }
        [Serialize(14), UInt16D(10, 0, 1000)]
        public double Saturation { get; set; }
        [Serialize(16), UInt16D(10, 0, 1000)]
        public double Luma { get; set; }
        [Serialize(18), UInt16D(10, 0, 3599)]
        public double LightSourceDirection { get; set; }
        [Serialize(20), UInt8D(1, 0, 100)]
        public double LightSourceAltitude { get; set; }
    }
}