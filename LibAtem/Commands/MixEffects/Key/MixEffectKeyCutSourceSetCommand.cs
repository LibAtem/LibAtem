using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKeC", 4)]
    public class MixEffectKeyCutSourceSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serialize(2), Enum16]
        public VideoSource CutSource { get; set; }
    }
}