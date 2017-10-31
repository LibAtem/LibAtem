using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Key;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKOn", 4)]
    public class MixEffectKeyOnAirSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        [Serialize(2), Bool]
        public bool OnAir { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            yield return new KeyOnAirMacroOp()
            {
                Index = MixEffectIndex,
                KeyIndex = KeyerIndex,
                OnAir = OnAir,
            };
        }
    }
}