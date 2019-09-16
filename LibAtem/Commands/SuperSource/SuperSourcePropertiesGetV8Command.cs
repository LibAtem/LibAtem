using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("SSrc", ProtocolVersion.V8_0, 16)]
    public class SuperSourcePropertiesGetV8Command : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public SuperSourceId SSrcId { get; set; }

        [Serialize(2), Enum16]
        public VideoSource ArtFillInput { get; set; }
        [Serialize(4), Enum16]
        public VideoSource ArtKeyInput { get; set; }
        [Serialize(6), Enum8]
        public SuperSourceArtOption ArtOption { get; set; }
        [Serialize(7), Bool]
        public bool ArtPreMultiplied { get; set; }
        [Serialize(8), UInt16D(10, 0, 1000)]
        public double ArtClip { get; set; }
        [Serialize(10), UInt16D(10, 0, 1000)]
        public double ArtGain { get; set; }
        [Serialize(12), Bool]
        public bool ArtInvertKey { get; set; }
    }
}