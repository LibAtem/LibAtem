using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Key;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKPt", 16)]
    public class MixEffectKeyPatternSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Pattern = 1 << 0,
            Size = 1 << 1,
            Symmetry = 1 << 2,
            Softness = 1 << 3,
            XPosition = 1 << 4,
            YPosition = 1 << 5,
            Inverse = 1 << 6,
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
        public Pattern Pattern { get; set; }
        [Serialize(4), UInt16D(100, 0, 10000)]
        public double Size { get; set; }
        [Serialize(6), UInt16D(100, 0, 10000)]
        public double Symmetry { get; set; }
        [Serialize(8), UInt16D(100, 0, 10000)]
        public double Softness { get; set; }
        [Serialize(10), UInt16D(10000, 0, 10000)]
        public double XPosition { get; set; }
        [Serialize(12), UInt16D(10000, 0, 10000)]
        public double YPosition { get; set; }
        [Serialize(14), Bool]
        public bool Inverse { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Pattern))
                yield return new PatternKeyPatternMacroOp {Index = MixEffectIndex, KeyIndex = KeyerIndex, Pattern = Pattern};
            if (Mask.HasFlag(MaskFlags.Size))
                yield return new PatternKeySizeMacroOp { Index = MixEffectIndex, KeyIndex = KeyerIndex, Size = Size };
            if (Mask.HasFlag(MaskFlags.Symmetry))
                yield return new PatternKeySymmetryMacroOp { Index = MixEffectIndex, KeyIndex = KeyerIndex, Symmetry = Symmetry };
            if (Mask.HasFlag(MaskFlags.Softness))
                yield return new PatternKeySoftnessMacroOp { Index = MixEffectIndex, KeyIndex = KeyerIndex, Softness = Softness };

            if (Mask.HasFlag(MaskFlags.XPosition))
                yield return new PatternKeyXPositionMacroOp { Index = MixEffectIndex, KeyIndex = KeyerIndex, XPosition = XPosition };
            if (Mask.HasFlag(MaskFlags.YPosition))
                yield return new PatternKeyYPositionMacroOp {Index = MixEffectIndex, KeyIndex = KeyerIndex, YPosition = YPosition};

            // Inverse

        }
    }
}