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
            FillSource = 1 << 0,
            CutSource = 1 << 1,
            ArtForeground = 1 << 2,
            PreMultiplied = 1 << 3,
            Clip = 1 << 4,
            Gain = 1 << 5,
            InvertKey = 1 << 6,
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
            LightSourceDirection = 1 << 18,
            LightSourceAltitude = 1 << 19,
        }

        [Serialize(0), Enum32]
        public MaskFlags Mask { get; set; }
        [Serialize(4), Enum16]
        public VideoSource ArtFillInput { get; set; }
        [Serialize(6), Enum16]
        public VideoSource ArtKeyInput { get; set; }
        [Serialize(8), Enum8]
        public SuperSourceArtOption ArtOption { get; set; }
        [Serialize(9), Bool]
        public bool ArtPreMultiplied { get; set; }
        [Serialize(10), UInt16D(1000, 0, 1000)]
        public double ArtClip { get; set; }
        [Serialize(12), UInt16D(1000, 0, 1000)]
        public double ArtGain { get; set; }
        [Serialize(14), Bool]
        public bool ArtInvertKey { get; set; }

        [Serialize(15), Bool]
        public bool BorderEnabled { get; set; }
        [Serialize(16), Enum8]
        public BorderBevel BorderBevel { get; set; }
        [Serialize(18), UInt16D(100, 0, 1600)]
        public double BorderWidthOut { get; set; }
        [Serialize(20), UInt16D(100, 0, 1600)]
        public double BorderWidthIn { get; set; }
        [Serialize(22), UInt8D(100, 0, 100)]
        public double BorderSoftnessOut { get; set; }
        [Serialize(23), UInt8D(100, 0, 100)]
        public double BorderSoftnessIn { get; set; }
        [Serialize(24), UInt8D(100, 0, 100)]
        public double BorderBevelSoftness { get; set; }
        [Serialize(25), UInt8D(100, 0, 100)]
        public double BorderBevelPosition { get; set; }
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
            if (Mask.HasFlag(MaskFlags.FillSource))
                yield return new SuperSourceArtFillInputMacroOp() {Source = ArtFillInput};

            if (Mask.HasFlag(MaskFlags.CutSource))
                yield return new SuperSourceArtCutInputMacroOp() {Source = ArtKeyInput};

            if (Mask.HasFlag(MaskFlags.ArtForeground))
                yield return new SuperSourceArtAboveMacroOp() {ArtAbove = ArtOption == SuperSourceArtOption.Foreground};

            if (Mask.HasFlag(MaskFlags.PreMultiplied))
                yield return null;

            if (Mask.HasFlag(MaskFlags.Clip))
                yield return null;

            if (Mask.HasFlag(MaskFlags.Gain))
                yield return null;

            if (Mask.HasFlag(MaskFlags.InvertKey))
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

            if (Mask.HasFlag(MaskFlags.LightSourceDirection))
                yield return null;

            if (Mask.HasFlag(MaskFlags.LightSourceAltitude))
                yield return null;

        }
    }
}