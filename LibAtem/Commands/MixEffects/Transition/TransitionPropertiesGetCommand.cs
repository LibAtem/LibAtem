using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TrSS", 8)]
    public class TransitionPropertiesGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), Enum8]
        public TStyle Style { get; set; }
        [Serialize(2), Enum8]
        public TransitionLayer Selection { get; set; }
        [Serialize(3), Enum8]
        public TStyle NextStyle { get; set; }
        [Serialize(4), Enum8]
        public TransitionLayer NextSelection { get; set; }
    }
}