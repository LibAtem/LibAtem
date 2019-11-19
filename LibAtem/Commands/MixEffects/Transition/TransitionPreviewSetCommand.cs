using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Transition;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTPr", CommandDirection.ToServer, 4)]
    public class TransitionPreviewSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), Bool]
        public bool PreviewTransition { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            yield return new TransitionPreviewMacroOp
            {
                Index = Index,
                Preview = PreviewTransition,
            };
        }
    }
}