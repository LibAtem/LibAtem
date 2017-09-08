using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects;
using LibAtem.Serialization;
using System.Collections.Generic;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("DAut", 4)]
    public class MixEffectAutoCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            yield return new AutoTransitionMacroOp()
            {
                Index = Index,
            };
        }
    }
}