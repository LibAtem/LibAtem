using LibAtem.Commands;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    public abstract class MixEffectKeyMacroOpBase : MixEffectMacroOpBase
    {
        [CommandId]
        [Serialize(5), UInt8]
        [MacroField("KeyIndex")]
        public uint KeyIndex { get; set; }
    }
}