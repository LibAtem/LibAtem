using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeCk", 12)]
    public class MixEffectKeyChromaGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serialize(2), UInt16D(10, 0, 3599)]
        public double Hue { get; set; }
        [Serialize(4), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double YSuppress { get; set; }
        [Serialize(8), UInt16D(10, 0, 1000)]
        public double Lift { get; set; }
        [Serialize(10), Bool]
        public bool Narrow { get; set; }
    }
}