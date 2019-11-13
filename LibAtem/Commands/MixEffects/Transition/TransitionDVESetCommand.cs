using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Transition.DVE;
using LibAtem.MacroOperations.MixEffects.Transition.Stinger;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTDv", 20)]
    public class TransitionDVESetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Rate = 1 << 0,
            LogoRate = 1 << 1,
            Style = 1 << 2,
            FillSource = 1 << 3,
            KeySource = 1 << 4,
            EnableKey = 1 << 5,
            PreMultiplied = 1 << 6,
            Clip = 1 << 7,
            Gain = 1 << 8,
            InvertKey = 1 << 9,
            Reverse = 1 << 10,
            FlipFlop = 1 << 11,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(2), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(3), UInt8Range(1, 250)]
        public uint Rate { get; set; }
        [Serialize(4), UInt8Range(1, 250)]
        public uint LogoRate { get; set; }
        [Serialize(5), Enum8]
        public DVEEffect Style { get; set; }

        [Serialize(6), Enum16]
        public VideoSource FillSource { get; set; }
        [Serialize(8), Enum16]
        public VideoSource KeySource { get; set; }

        [Serialize(10), Bool]
        public bool EnableKey { get; set; }
        [Serialize(11), Bool]
        public bool PreMultiplied { get; set; }
        [Serialize(12), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serialize(14), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(16), Bool]
        public bool InvertKey { get; set; }
        [Serialize(17), Bool]
        public bool Reverse { get; set; }
        [Serialize(18), Bool]
        public bool FlipFlop { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            if (Mask.HasFlag(MaskFlags.Rate))
                yield return new TransitionDVERateMacroOp { Index = Index, Rate = Rate };
            if (Mask.HasFlag(MaskFlags.LogoRate))
                yield return null;
            if (Mask.HasFlag(MaskFlags.Style))
                yield return new TransitionDVEPatternMacroOp { Index = Index, Pattern = Style };

            if (Mask.HasFlag(MaskFlags.FillSource))
                yield return new TransitionDVEFillInputMacroOp { Index = Index, Input = FillSource };
            if (Mask.HasFlag(MaskFlags.KeySource))
                yield return new TransitionDVECutInputMacroOp { Index = Index, Input = KeySource };

            if (Mask.HasFlag(MaskFlags.EnableKey))
                yield return new TransitionDVECutInputEnableMacroOp { Index = Index, Enable = EnableKey };
            if (Mask.HasFlag(MaskFlags.PreMultiplied))
                yield return null;
            if (Mask.HasFlag(MaskFlags.Clip))
                yield return null;
            if (Mask.HasFlag(MaskFlags.Gain))
                yield return null;
            if (Mask.HasFlag(MaskFlags.InvertKey))
                yield return null;
            if (Mask.HasFlag(MaskFlags.Reverse))
                yield return null;
            if (Mask.HasFlag(MaskFlags.FlipFlop))
                yield return null;
        }
    }

}