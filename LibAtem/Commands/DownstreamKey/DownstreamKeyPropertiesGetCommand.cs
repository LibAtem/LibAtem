using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DskP", 20)]
    public class DownstreamKeyPropertiesGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serialize(1), Bool]
        public bool Tie { get; set; }
        [Serialize(2), UInt8Range(0, 250)]
        public uint Rate { get; set; }

        [Serialize(3), Bool]
        public bool PreMultipliedKey { get; set; }
        [Serialize(4), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(8), Bool]
        public bool Invert { get; set; }

        [Serialize(9), Bool]
        public bool MaskEnabled { get; set; }
        [Serialize(10), Int16D(1000, -9000, 9000)]
        public double MaskTop { get; set; }
        [Serialize(12), Int16D(1000, -9000, 9000)]
        public double MaskBottom { get; set; }
        [Serialize(14), Int16D(1000, -16000, 16000)]
        public double MaskLeft { get; set; }
        [Serialize(16), Int16D(1000, -16000, 16000)]
        public double MaskRight { get; set; }
    }
}