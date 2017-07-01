using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("FtbA", 4)]
    public class FadeToBlackAutoCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
    }
}