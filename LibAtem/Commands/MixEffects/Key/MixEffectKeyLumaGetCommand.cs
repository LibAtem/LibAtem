using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeLm", 12)]
    public class MixEffectKeyLumaGetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serialize(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serialize(2), Bool]
        public bool PreMultiplied { get; set; }
        [Serialize(4), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(8), Bool]
        public bool Invert { get; set; }
    }
}