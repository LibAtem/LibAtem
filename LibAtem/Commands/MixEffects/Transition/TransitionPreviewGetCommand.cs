using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TrPr", 4)]
    public class TransitionPreviewGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(1), Bool]
        public bool PreviewTransition { get; set; }
        
    }
}