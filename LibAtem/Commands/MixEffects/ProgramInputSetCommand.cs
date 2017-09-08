using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects;
using LibAtem.Serialization;
using System.Collections.Generic;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("CPgI", 4)]
    public class ProgramInputSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(2), Enum16]
        public VideoSource Source { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            yield return new ProgramInputMacroOp()
            {
                Index = Index,
                Source = Source,
            };
        }
    }
}