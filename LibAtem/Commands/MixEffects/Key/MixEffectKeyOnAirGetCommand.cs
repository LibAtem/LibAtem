using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeOn", 4)]
    public class MixEffectKeyOnAirGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serializable(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serializable(2), Bool]
        public bool OnAir { get; set; }
    }
}