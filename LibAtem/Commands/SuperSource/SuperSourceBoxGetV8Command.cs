using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("SSBP", CommandDirection.ToClient, ProtocolVersion.V8_0, 24)]
    public class SuperSourceBoxGetV8Command : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public SuperSourceId SSrcId { get; set; }

        [CommandId]
        [Serialize(1), Enum8]
        public SuperSourceBoxId BoxIndex { get; set; }

        [Serialize(2), Bool]
        public bool Enabled { get; set; }

        [Serialize(4), Enum16]
        public VideoSource Source { get; set; }

        [Serialize(6), Int16D(100, -4800, 4800)]
        public double PositionX { get; set; }

        [Serialize(8), Int16D(100, -3400, 3400)]
        public double PositionY { get; set; }

        [Serialize(10), UInt16D(1000, 70, 1000)]
        public double Size { get; set; }

        [Serialize(12), Bool]
        public bool Cropped { get; set; }

        [Serialize(14), UInt16D(1000, 0, 18000)]
        public double CropTop { get; set; }

        [Serialize(16), UInt16D(1000, 0, 18000)]
        public double CropBottom { get; set; }

        [Serialize(18), UInt16D(1000, 0, 32000)]
        public double CropLeft { get; set; }

        [Serialize(20), UInt16D(1000, 0, 32000)]
        public double CropRight { get; set; }
    }
}