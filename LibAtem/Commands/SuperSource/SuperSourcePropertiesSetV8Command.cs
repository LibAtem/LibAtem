using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.SuperSource;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("CSSc", ProtocolVersion.V8_0, 16)]
    public class SuperSourcePropertiesSetV8Command : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            ArtFillSource = 1 << 0,
            ArtCutSource = 1 << 1,
            ArtOption = 1 << 2,
            ArtPreMultiplied = 1 << 3,
            ArtClip = 1 << 4,
            ArtGain = 1 << 5,
            ArtInvertKey = 1 << 6,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(1), Enum8]
        public SuperSourceId SSrcId { get; set; }

        [Serialize(2), Enum16]
        public VideoSource ArtFillSource { get; set; }
        [Serialize(4), Enum16]
        public VideoSource ArtCutSource { get; set; }
        [Serialize(6), Enum8]
        public SuperSourceArtOption ArtOption { get; set; }
        [Serialize(7), Bool]
        public bool ArtPreMultiplied { get; set; }
        [Serialize(8), UInt16D(10, 0, 1000)]
        public double ArtClip { get; set; }
        [Serialize(10), UInt16D(10, 0, 1000)]
        public double ArtGain { get; set; }
        [Serialize(12), Bool]
        public bool ArtInvertKey { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.ArtFillSource))
                yield return new SuperSourceArtFillInputMacroOp() { SSrcId = SSrcId, Source = ArtFillSource };

            if (Mask.HasFlag(MaskFlags.ArtCutSource))
                yield return new SuperSourceArtCutInputMacroOp() { SSrcId = SSrcId, Source = ArtCutSource };

            if (Mask.HasFlag(MaskFlags.ArtOption))
                yield return new SuperSourceArtAboveMacroOp() { SSrcId = SSrcId, ArtAbove = ArtOption == SuperSourceArtOption.Foreground };

            if (Mask.HasFlag(MaskFlags.ArtPreMultiplied))
                yield return new SuperSourceArtPreMultiplyMacroOp { SSrcId = SSrcId, PreMultiply = ArtPreMultiplied };

            if (Mask.HasFlag(MaskFlags.ArtClip))
                yield return new SuperSourceArtClipMacroOp { SSrcId = SSrcId, Clip = ArtClip };

            if (Mask.HasFlag(MaskFlags.ArtGain))
                yield return new SuperSourceArtGainMacroOp { SSrcId = SSrcId, Gain = ArtGain };

            if (Mask.HasFlag(MaskFlags.ArtInvertKey))
                yield return new SuperSourceArtInvertMacroOp { SSrcId = SSrcId, Invert = ArtInvertKey }; ;
        }
    }
}