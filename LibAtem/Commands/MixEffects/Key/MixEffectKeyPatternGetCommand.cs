using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KePt", 16)]
    public class MixEffectKeyPatternGetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serialize(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serialize(2), Enum8]
        public Pattern Style { get; set; }
        [Serialize(4), UInt16D(100, 0, 10000)]
        public double Size { get; set; }
        [Serialize(6), UInt16D(100, 0, 10000)]
        public double Symmetry { get; set; }
        [Serialize(8), UInt16D(100, 0, 10000)]
        public double Softness { get; set; }
        [Serialize(10), UInt16D(10000, 0, 10000)]
        public double XPosition { get; set; }
        [Serialize(12), UInt16D(10000, 0, 10000)]
        public double YPosition { get; set; }
        [Serialize(14), Bool]
        public bool Inverse { get; set; }
    }
}