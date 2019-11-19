using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TrPr", CommandDirection.ToClient, 4)]
    public class TransitionPreviewGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), Bool]
        public bool PreviewTransition { get; set; }
        
    }
}