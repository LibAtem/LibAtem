using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects;
using LibAtem.Serialization;
using System.Collections.Generic;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("DCut", CommandDirection.ToServer, 4)]
    public class MixEffectCutCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            yield return new CutTransitionMacroOp()
            {
                Index = Index,
            };
        }
    }
}
