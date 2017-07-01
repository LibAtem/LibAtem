using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKeF", 4)]
    public class MixEffectKeyFillSourceSetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serialize(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serialize(2), Enum16]
        public VideoSource FillSource { get; set; }
    }
}