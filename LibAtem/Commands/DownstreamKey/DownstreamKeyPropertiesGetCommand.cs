using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DskP", 20)]
    public class DownstreamKeyPropertiesGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public DownstreamKeyId Index { get; set; }
        [Serializable(1), Bool]
        public bool Tie { get; set; }
        [Serializable(2), UInt8Range(0, 250)]
        public uint Rate { get; set; }

        [Serializable(3), Bool]
        public bool PreMultipliedKey { get; set; }
        [Serializable(4), UInt16D(10, 0, 100)]
        public double Clip { get; set; }
        [Serializable(6), UInt16D(10, 0, 100)]
        public double Gain { get; set; }
        [Serializable(8), Bool]
        public bool Invert { get; set; }

        [Serializable(9), Bool]
        public bool MaskEnabled { get; set; }
        [Serializable(10), Int16D(1000, -9000, 9000)]
        public double MaskTop { get; set; }
        [Serializable(12), Int16D(1000, -9000, 9000)]
        public double MaskBottom { get; set; }
        [Serializable(14), Int16D(1000, -16000, 16000)]
        public double MaskLeft { get; set; }
        [Serializable(16), Int16D(1000, -16000, 16000)]
        public double MaskRight { get; set; }
    }
}