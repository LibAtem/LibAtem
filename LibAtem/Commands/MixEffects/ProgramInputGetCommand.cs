using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("PrgI", 4)]
    public class ProgramInputGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(2), Enum16]
        public VideoSource Source { get; set; }
    }
}