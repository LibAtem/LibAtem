using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTPr", 4)]
    public class TransitionPreviewSetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(1), Bool]
        public bool PreviewTransition { get; set; }
    }
}