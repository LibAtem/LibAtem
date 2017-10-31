using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Key;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKTp", 8)]
    public class MixEffectKeyTypeSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Type = 1 << 0,
            FlyEnabled = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(2), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        [Serialize(3), Enum8]
        public MixEffectKeyType KeyType { get; set; }
        [Serialize(4), Bool]
        public bool FlyEnabled { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Type))
                yield return new KeyTypeMacroOp()
                {
                    Index = MixEffectIndex,
                    KeyIndex = KeyerIndex,
                    KeyType = KeyType,
                };

            if (Mask.HasFlag(MaskFlags.FlyEnabled))
                yield return null;
        }
    }
}