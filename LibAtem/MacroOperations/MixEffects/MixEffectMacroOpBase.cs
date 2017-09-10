using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects
{
    public abstract class MixEffectMacroOpBase : MacroOpBase
    {
        [CommandId]
        [Serialize(4), Enum8]
        [MacroField("MixEffectBlockIndex")]
        public MixEffectBlockId Index { get; set; }
    }
}