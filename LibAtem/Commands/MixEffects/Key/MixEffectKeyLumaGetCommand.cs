using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeLm", 12)]
    public class MixEffectKeyLumaGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serializable(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serializable(2), Bool]
        public bool PreMultiplied { get; set; }
        [Serializable(4), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serializable(6), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serializable(8), Bool]
        public bool Invert { get; set; }
    }
}