using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TrSS", 8)]
    public class TransitionPropertiesGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(1), Enum8]
        public TStyle Style { get; set; }
        [Serializable(2), Enum8]
        public TransitionLayer Selection { get; set; }
        [Serializable(3), Enum8]
        public TStyle NextStyle { get; set; }
        [Serializable(4), Enum8]
        public TransitionLayer NextSelection { get; set; }
    }
}