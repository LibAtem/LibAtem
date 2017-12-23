using System;
using LibAtem.Common;
using LibAtem.MacroOperations.MixEffects.Transition;
using LibAtem.Serialization;
using LibAtem.MacroOperations;
using System.Collections.Generic;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTSt", 20)]
    public class TransitionStingerSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Source           = 1 << 0,
            PreMultipliedKey = 1 << 1,
            Clip             = 1 << 2,
            Gain             = 1 << 3,
            Invert           = 1 << 4,
            Preroll          = 1 << 5,
            ClipDuration     = 1 << 6,
            TriggerPoint     = 1 << 7,
            MixRate          = 1 << 8,

            Durations = Preroll | ClipDuration | TriggerPoint | MixRate,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(3), Enum8]
        public StingerSource Source { get; set; }
        [Serialize(4), Bool]
        public bool PreMultipliedKey { get; set; }

        [Serialize(6), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serialize(8), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(10), Bool]
        public bool Invert { get; set; }

        [Serialize(12), UInt16]
        public uint Preroll { get; set; }
        [Serialize(14), UInt16]
        public uint ClipDuration { get; set; }
        [Serialize(16), UInt16]
        public uint TriggerPoint { get; set; }
        [Serialize(18), UInt16]
        public uint MixRate { get; set; }

        // TODO - additional validation

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Source))
                yield return new TransitionStingerSourceMediaPlayerMacroOp {Index = Index, Source = Source};
            if (Mask.HasFlag(MaskFlags.PreMultipliedKey))
                yield return new TransitionStingerDVEPreMultiplyMacroOp {Index = Index, PreMultiply = PreMultipliedKey};

            if (Mask.HasFlag(MaskFlags.Clip))
                yield return new TransitionStingerDVEClipMacroOp {Index = Index, Clip = Clip};
            if (Mask.HasFlag(MaskFlags.Gain))
                yield return new TransitionStingerDVEGainMacroOp { Index = Index, Gain = Gain };
            if (Mask.HasFlag(MaskFlags.Invert))
                yield return new TransitionStingerDVEInvertMacroOp { Index = Index, Invert = Invert };

            if (Mask.HasFlag(MaskFlags.Preroll))
                yield return new TransitionStingerPreRollMacroOp {Index = Index, Preroll = Preroll};
            if (Mask.HasFlag(MaskFlags.ClipDuration))
                yield return new TransitionStingerClipDurationMacroOp {Index = Index, ClipDuration = ClipDuration};
            if (Mask.HasFlag(MaskFlags.TriggerPoint))
                yield return new TransitionStingerTriggerPointMacroOp {Index = Index, TriggerPoint = TriggerPoint};
            if (Mask.HasFlag(MaskFlags.MixRate))
                yield return new TransitionStingerMixRateMacroOp {Index = Index, MixRate = MixRate};
        }
    }
}