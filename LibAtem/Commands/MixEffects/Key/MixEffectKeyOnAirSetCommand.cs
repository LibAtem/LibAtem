using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKOn", 4)]
    public class MixEffectKeyOnAirSetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serialize(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serialize(2), Bool]
        public bool OnAir { get; set; }
    }
}