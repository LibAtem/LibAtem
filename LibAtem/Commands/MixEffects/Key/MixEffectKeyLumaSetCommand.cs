using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Key.Luma;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKLm", 12)]
    public class MixEffectKeyLumaSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            PreMultiplied = 1 << 0,
            Clip = 1 << 1,
            Gain = 1 << 2,
            Invert = 1 << 3,
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
        public bool PreMultiplied { get; set; }
        [Serialize(4), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(8), Bool]
        public bool Invert { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            if (Mask.HasFlag(MaskFlags.PreMultiplied))
                yield return new LumaKeyPreMultiplyMacroOp()
                {
                    Index = MixEffectIndex,
                    KeyIndex = KeyerIndex,
                    PreMultiply = PreMultiplied,
                };
            if (Mask.HasFlag(MaskFlags.Clip))
                yield return new LumaKeyClipMacroOp()
                {
                    Index = MixEffectIndex,
                    KeyIndex = KeyerIndex,
                    Clip = Clip,
                };
            if (Mask.HasFlag(MaskFlags.Gain))
                yield return new LumaKeyGainMacroOp()
                {
                    Index = MixEffectIndex,
                    KeyIndex = KeyerIndex,
                    Gain = Gain,
                };
            if (Mask.HasFlag(MaskFlags.Invert))
                yield return new LumaKeyInvertMacroOp()
                {
                    Index = MixEffectIndex,
                    KeyIndex = KeyerIndex,
                    Invert = Invert,
                };

        }
    }
}