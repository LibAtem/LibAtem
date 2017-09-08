using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects
{
    public abstract class MixEffectMacroOpBase : MacroOpBase
    {
        [CommandId]
        [Serialize(4), Enum16]
        [MacroField("MixEffectBlockIndex")] // TODO Should this be defined elsewhere?
        public MixEffectBlockId Index { get; set; }
    }
}