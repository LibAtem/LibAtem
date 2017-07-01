using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeCk", 12)]
    public class MixEffectKeyChromaGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serializable(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serializable(2), UInt16D(10, 0, 3599)]
        public double Hue { get; set; }
        [Serializable(4), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serializable(6), UInt16D(10, 0, 1000)]
        public double YSuppress { get; set; }
        [Serializable(8), UInt16D(10, 0, 1000)]
        public double Lift { get; set; }
        [Serializable(10), Bool]
        public bool Narrow { get; set; }
    }
}