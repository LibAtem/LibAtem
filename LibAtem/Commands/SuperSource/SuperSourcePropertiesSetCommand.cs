using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.SuperSource;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("CSSc", 36), NoCommandId]
    public class SuperSourcePropertiesSetCommand : SerializableCommandBase
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
            BorderEnabled = 1 << 7,
            BorderBevel = 1 << 8,
            BorderOuterWidth = 1 << 9,
            BorderInnerWidth = 1 << 10,
            BorderOuterSoftness = 1 << 11,
            BorderInnerSoftness = 1 << 12,
            BorderBevelSoftness = 1 << 13,
            BorderBevelPosition = 1 << 14,
            BorderHue = 1 << 15,
            BorderSaturation = 1 << 16,
            BorderLuma = 1 << 17,
            BorderLightSourceDirection = 1 << 18,
            BorderLightSourceAltitude = 1 << 19,
        }

        [Serialize(0), Enum32]
        public MaskFlags Mask { get; set; }
        [Serialize(4), Enum16]
        public VideoSource ArtFillSource { get; set; }
        [Serialize(6), Enum16]
        public VideoSource ArtCutSource { get; set; }
        [Serialize(8), Enum8]
        public SuperSourceArtOption ArtOption { get; set; }
        [Serialize(9), Bool]
        public bool ArtPreMultiplied { get; set; }
        [Serialize(10), UInt16D(10, 0, 1000)]
        public double ArtClip { get; set; }
        [Serialize(12), UInt16D(10, 0, 1000)]
        public double ArtGain { get; set; }
        [Serialize(14), Bool]
        public bool ArtInvertKey { get; set; }

        [Serialize(15), Bool]
        public bool BorderEnabled { get; set; }
        [Serialize(16), Enum8]
        public BorderBevel BorderBevel { get; set; }
        [Serialize(18), UInt16D(100, 0, 1600)]
        public double BorderOuterWidth { get; set; }
        [Serialize(20), UInt16D(100, 0, 1600)]
        public double BorderInnerWidth { get; set; }
        [Serialize(22), UInt8Range(0, 100)]
        public uint BorderOuterSoftness { get; set; }
        [Serialize(23), UInt8Range(0, 100)]
        public uint BorderInnerSoftness { get; set; }
        [Serialize(24), UInt8Range(0, 100)]
        public uint BorderBevelSoftness { get; set; }
        [Serialize(25), UInt8Range(0, 100)]
        public uint BorderBevelPosition { get; set; }
        [Serialize(26), UInt16D(10, 0, 3599)]
        public double BorderHue { get; set; }
        [Serialize(28), UInt16D(10, 0, 1000)]
        public double BorderSaturation { get; set; }
        [Serialize(30), UInt16D(10, 0, 1000)]
        public double BorderLuma { get; set; }
        [Serialize(32), UInt16D(10, 0, 3590)]
        public double BorderLightSourceDirection { get; set; }
        [Serialize(34), UInt8D(1, 0, 100)]
        public double BorderLightSourceAltitude { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.ArtFillSource))
                yield return new SuperSourceArtFillInputMacroOp() {Source = ArtFillSource };

            if (Mask.HasFlag(MaskFlags.ArtCutSource))
                yield return new SuperSourceArtCutInputMacroOp() {Source = ArtCutSource};

            if (Mask.HasFlag(MaskFlags.ArtOption))
                yield return new SuperSourceArtAboveMacroOp() {ArtAbove = ArtOption == SuperSourceArtOption.Foreground};

            if (Mask.HasFlag(MaskFlags.ArtPreMultiplied))
                yield return null;

            if (Mask.HasFlag(MaskFlags.ArtClip))
                yield return null;

            if (Mask.HasFlag(MaskFlags.ArtGain))
                yield return null;

            if (Mask.HasFlag(MaskFlags.ArtInvertKey))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderEnabled))
                yield return new SuperSourceBorderEnableMacroOp() {Enable = BorderEnabled};

            if (Mask.HasFlag(MaskFlags.BorderBevel))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderOuterWidth))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderInnerWidth))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderOuterSoftness))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderInnerSoftness))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderBevelSoftness))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderBevelPosition))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderHue))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderSaturation))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderLuma))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderLightSourceDirection))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderLightSourceAltitude))
                yield return null;

        }
    }
}