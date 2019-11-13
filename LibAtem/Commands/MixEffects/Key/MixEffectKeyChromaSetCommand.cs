using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Key.Chroma;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKCk", 16)]
    public class MixEffectKeyChromaSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Hue = 1 << 0,
            Gain = 1 << 1,
            YSuppress = 1 << 2,
            Lift = 1 << 3,
            Narrow = 1 << 4,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(2), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        [Serialize(4), UInt16D(10, 0, 3599)]
        public double Hue { get; set; }
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(8), UInt16D(10, 0, 1000)]
        public double YSuppress { get; set; }
        [Serialize(10), UInt16D(10, 0, 1000)]
        public double Lift { get; set; }
        [Serialize(12), Bool]
        public bool Narrow { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            if (Mask.HasFlag(MaskFlags.Hue))
                yield return new ChromaKeyHueMacroOp { Index = MixEffectIndex, KeyIndex = KeyerIndex, Hue = Hue };
            if (Mask.HasFlag(MaskFlags.Gain))
                yield return new ChromaKeyGainMacroOp { Index = MixEffectIndex, KeyIndex = KeyerIndex, Gain = Gain };
            if (Mask.HasFlag(MaskFlags.YSuppress))
                yield return new ChromaKeyYSuppressMacroOp { Index = MixEffectIndex, KeyIndex = KeyerIndex, YSuppress = YSuppress };
            if (Mask.HasFlag(MaskFlags.Lift))
                yield return new ChromaKeyLiftMacroOp { Index = MixEffectIndex, KeyIndex = KeyerIndex, Lift = Lift };
            if (Mask.HasFlag(MaskFlags.Narrow))
                yield return new ChromaKeyNarrowMacroOp { Index = MixEffectIndex, KeyIndex = KeyerIndex, Narrow = Narrow };
        }
    }
}