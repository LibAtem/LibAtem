using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("SSrc", CommandDirection.ToClient, ProtocolVersion.V8_0, 16)]
    public class SuperSourcePropertiesGetV8Command : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public SuperSourceId SSrcId { get; set; }

        [Serialize(2), Enum16]
        public VideoSource ArtFillSource { get; set; }
        [Serialize(4), Enum16]
        public VideoSource ArtCutSource { get; set; }
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