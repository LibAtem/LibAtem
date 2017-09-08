using LibAtem.Commands;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    public abstract class MixEffectKeyMacroOpBase : MixEffectMacroOpBase
    {
        [CommandId]
        [Serialize(6), UInt16]
        [MacroField("KeyIndex")]
        public uint KeyIndex { get; set; }
    }
}