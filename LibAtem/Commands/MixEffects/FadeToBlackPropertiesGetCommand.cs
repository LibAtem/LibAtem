using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("FtbP", 4)]
    public class FadeToBlackPropertiesGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(1), UInt8Range(0, 250)]
        public uint Rate { get; set; }
    }
}