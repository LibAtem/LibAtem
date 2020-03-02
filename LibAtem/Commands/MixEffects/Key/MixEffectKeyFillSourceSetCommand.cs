using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Key;
using LibAtem.Serialization;
using System.Collections.Generic;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKeF", CommandDirection.ToServer, 4)]
    public class MixEffectKeyFillSourceSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serialize(1), Enum8]
        [CommandId]
        public UpstreamKeyId KeyerIndex { get; set; }
        [Serialize(2), Enum16]
        public VideoSource FillSource { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            yield return new KeyFillInputMacroOp()
            {
                Index = MixEffectIndex,
                KeyIndex = KeyerIndex,
                Source = FillSource,
            };
        }
    }
}