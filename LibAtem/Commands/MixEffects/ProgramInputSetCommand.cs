using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("CPgI", 4)]
    public class ProgramInputSetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(2), Enum16]
        public VideoSource Source { get; set; }
    }
}