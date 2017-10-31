using System;
using LibAtem.Common;
using LibAtem.MacroOperations.MixEffects.Key;
using LibAtem.Serialization;
using LibAtem.MacroOperations;
using System.Collections.Generic;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKMs", 12)]
    public class MixEffectKeyMaskSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Enabled = 1 << 0,
            MaskTop = 1 << 1,
            MaskBottom = 1 << 2,
            MaskLeft = 1 << 3,
            MaskRight = 1 << 4,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(2), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        [Serialize(3), Bool]
        public bool MaskEnabled { get; set; }
        [Serialize(4), Int16D(1000, -9000, 9000)]
        public double MaskTop { get; set; }
        [Serialize(6), Int16D(1000, -9000, 9000)]
        public double MaskBottom { get; set; }
        [Serialize(8), Int16D(1000, -16000, 16000)]
        public double MaskLeft { get; set; }
        [Serialize(10), Int16D(1000, -16000, 16000)]
        public double MaskRight { get; set; }


        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Enabled))
                yield return new KeyMaskEnableMacroOp()
                {
                    Index = MixEffectIndex,
                    KeyIndex = KeyerIndex,
                    Enable = MaskEnabled,
                };

            if (Mask.HasFlag(MaskFlags.MaskTop))
                yield return new KeyMaskTopMacroOp()
                {
                    Index = MixEffectIndex,
                    KeyIndex = KeyerIndex,
                    Top = MaskTop,
                };

            if (Mask.HasFlag(MaskFlags.MaskBottom))
                yield return new KeyMaskBottomMacroOp()
                {
                    Index = MixEffectIndex,
                    KeyIndex = KeyerIndex,
                    Bottom = MaskBottom,
                };

            if (Mask.HasFlag(MaskFlags.MaskLeft))
                yield return new KeyMaskLeftMacroOp()
                {
                    Index = MixEffectIndex,
                    KeyIndex = KeyerIndex,
                    Left = MaskLeft,
                };

            if (Mask.HasFlag(MaskFlags.MaskRight))
                yield return new KeyMaskRightMacroOp()
                {
                    Index = MixEffectIndex,
                    KeyIndex = KeyerIndex,
                    Right = MaskRight,
                };
        }
    }
}