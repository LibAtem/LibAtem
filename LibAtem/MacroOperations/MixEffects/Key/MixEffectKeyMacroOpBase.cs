using LibAtem.Commands;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Key
{
    public abstract class MixEffectKeyMacroOpBase : MixEffectMacroOpBase
    {
        [CommandId]
        [Serialize(5), Enum8]
        [MacroField("UpstreamKeyIndex", "keyIndex")]
        public UpstreamKeyId KeyIndex { get; set; }
    }
}