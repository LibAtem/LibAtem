using System;
using LibAtem.Common;
using LibAtem.MacroOperations.MixEffects.Transition;
using LibAtem.Serialization;
using LibAtem.MacroOperations;
using System.Collections.Generic;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTWp", 20)]
    public class TransitionWipeSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Rate = 1 << 0,
            Pattern = 1 << 1,
            BorderWidth = 1 << 2,
            BorderInput = 1 << 3,
            Symmetry = 1 << 4,
            BorderSoftness = 1 << 5,
            XPosition = 1 << 6,
            YPosition = 1 << 7,
            ReverseDirection = 1 << 8,
            FlipFlop = 1 << 9,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(3), UInt8Range(1, 250)]
        public uint Rate { get; set; }
        [Serialize(4), Enum8]
        public Pattern Pattern { get; set; }
        [Serialize(6), UInt16D(100, 0, 10000)]
        public double BorderWidth { get; set; }
        [Serialize(8), Enum16]
        public VideoSource BorderInput { get; set; }
        [Serialize(10), UInt16D(100, 0, 10000)]
        public double Symmetry { get; set; }
        [Serialize(12), UInt16D(100, 0, 10000)]
        public double BorderSoftness { get; set; }
        [Serialize(14), UInt16D(10000, 0, 10000)]
        public double XPosition { get; set; }
        [Serialize(16), UInt16D(10000, 0, 10000)]
        public double YPosition { get; set; }
        [Serialize(18), Bool]
        public bool ReverseDirection { get; set; }
        [Serialize(19), Bool]
        public bool FlipFlop { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Rate))
                yield return new TransitionWipeRateMacroOp {Index = Index, Rate = Rate};
            if (Mask.HasFlag(MaskFlags.Pattern))
                yield return new TransitionWipePatternMacroOp {Index = Index, Pattern = Pattern};
            if (Mask.HasFlag(MaskFlags.BorderWidth))
                yield return new TransitionWipeBorderWidthMacroOp {Index = Index, BorderWidth = BorderWidth};
            if (Mask.HasFlag(MaskFlags.BorderInput))
                yield return new TransitionWipeBorderFillInputMacroOp {Index = Index, Input = BorderInput};
            if (Mask.HasFlag(MaskFlags.Symmetry))
                yield return new TransitionWipeSymmetryMacroOp {Index = Index, Symmetry = Symmetry};
            if (Mask.HasFlag(MaskFlags.BorderSoftness))
                yield return new TransitionWipeBorderSoftnessMacroOp {Index = Index, BorderSoftness = BorderSoftness};
            if (Mask.HasFlag(MaskFlags.XPosition))
                yield return new TransitionWipeXPositionMacroOp {Index = Index, XPosition = XPosition};
            if (Mask.HasFlag(MaskFlags.YPosition))
                yield return new TransitionWipeYPositionMacroOp {Index = Index, YPosition = YPosition};
            if (Mask.HasFlag(MaskFlags.ReverseDirection))
                yield return new TransitionWipeAndDVEReverseMacroOp {Index = Index, ReverseDirection = ReverseDirection};
            if (Mask.HasFlag(MaskFlags.FlipFlop))
                yield return new TransitionWipeAndDVEFlipFlopMacroOp {Index = Index, FlipFlop = FlipFlop};

        }
    }
}