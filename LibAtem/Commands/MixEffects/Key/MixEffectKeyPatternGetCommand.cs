using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KePt", 16)]
    public class MixEffectKeyPatternGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serializable(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serializable(2), Enum8]
        public Pattern Style { get; set; }
        [Serializable(4), UInt16D(100, 0, 10000)]
        public double Size { get; set; }
        [Serializable(6), UInt16D(100, 0, 10000)]
        public double Symmetry { get; set; }
        [Serializable(8), UInt16D(100, 0, 10000)]
        public double Softness { get; set; }
        [Serializable(10), UInt16D(10000, 0, 10000)]
        public double XPosition { get; set; }
        [Serializable(12), UInt16D(10000, 0, 10000)]
        public double YPosition { get; set; }
        [Serializable(14), Bool]
        public bool Inverse { get; set; }
    }
}