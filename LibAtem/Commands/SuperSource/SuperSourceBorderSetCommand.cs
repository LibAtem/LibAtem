using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.SuperSource;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("CSBd", ProtocolVersion.V8_0, 24)]
    public class SuperSourceBorderSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            BorderEnabled = 1 << 0,
            BorderBevel = 1 << 1,
            BorderOuterWidth = 1 << 2,
            BorderInnerWidth = 1 << 3,
            BorderOuterSoftness = 1 << 4,
            BorderInnerSoftness = 1 << 5,
            BorderBevelSoftness = 1 << 6,
            BorderBevelPosition = 1 << 7,
            BorderHue = 1 << 8,
            BorderSaturation = 1 << 9,
            BorderLuma = 1 << 10,
            BorderLightSourceDirection = 1 << 11,
            BorderLightSourceAltitude = 1 << 12,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(2), Enum8]
        public SuperSourceId SSrcId { get; set; }

        [Serialize(3), Bool]
        public bool BorderEnabled { get; set; }
        [Serialize(4), Enum8]
        public BorderBevel BorderBevel { get; set; }
        [Serialize(6), UInt16D(100, 0, 1600)]
        public double BorderOuterWidth { get; set; }
        [Serialize(8), UInt16D(100, 0, 1600)]
        public double BorderInnerWidth { get; set; }
        [Serialize(10), UInt8Range(0, 100)]
        public uint BorderOuterSoftness { get; set; }
        [Serialize(11), UInt8Range(0, 100)]
        public uint BorderInnerSoftness { get; set; }
        [Serialize(12), UInt8Range(0, 100)]
        public uint BorderBevelSoftness { get; set; }
        [Serialize(13), UInt8Range(0, 100)]
        public uint BorderBevelPosition { get; set; }
        [Serialize(14), UInt16D(10, 0, 3599)]
        public double BorderHue { get; set; }
        [Serialize(16), UInt16D(10, 0, 1000)]
        public double BorderSaturation { get; set; }
        [Serialize(18), UInt16D(10, 0, 1000)]
        public double BorderLuma { get; set; }
        [Serialize(20), UInt16D(10, 0, 3599)]
        public double BorderLightSourceDirection { get; set; }
        [Serialize(22), UInt8Range(0, 100)]
        public uint BorderLightSourceAltitude { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.BorderEnabled))
                yield return new SuperSourceV2BorderEnableMacroOp() { SSrcId = SSrcId, Enable = BorderEnabled };

            if (Mask.HasFlag(MaskFlags.BorderBevel))
                yield return new SuperSourceV2BorderBevelMacroOp { SSrcId = SSrcId, Bevel = BorderBevel };

            if (Mask.HasFlag(MaskFlags.BorderOuterWidth))
                yield return new SuperSourceV2BorderOuterWidthMacroOp { SSrcId = SSrcId, OuterWidth = BorderOuterWidth };

            if (Mask.HasFlag(MaskFlags.BorderInnerWidth))
                yield return new SuperSourceV2BorderInnerWidthMacroOp { SSrcId = SSrcId, InnerWidth = BorderInnerWidth };

            if (Mask.HasFlag(MaskFlags.BorderOuterSoftness))
                yield return new SuperSourceV2BorderOuterSoftnessMacroOp { SSrcId = SSrcId, OuterSoftness = BorderOuterSoftness };

            if (Mask.HasFlag(MaskFlags.BorderInnerSoftness))
                yield return new SuperSourceV2BorderInnerSoftnessMacroOp { SSrcId = SSrcId, InnerSoftness = BorderInnerSoftness };

            if (Mask.HasFlag(MaskFlags.BorderBevelSoftness))
                yield return new SuperSourceV2BorderBevelSoftnessMacroOp { SSrcId = SSrcId, BevelSoftness = BorderBevelSoftness };

            if (Mask.HasFlag(MaskFlags.BorderBevelPosition))
                yield return new SuperSourceV2BorderBevelPositionMacroOp { SSrcId = SSrcId, BevelPosition = BorderBevelPosition };

            if (Mask.HasFlag(MaskFlags.BorderHue))
                yield return new SuperSourceV2BorderHueMacroOp { SSrcId = SSrcId, Hue = BorderHue };

            if (Mask.HasFlag(MaskFlags.BorderSaturation))
                yield return new SuperSourceV2BorderSaturationMacroOp { SSrcId = SSrcId, Saturation = BorderSaturation };

            if (Mask.HasFlag(MaskFlags.BorderLuma))
                yield return new SuperSourceV2BorderLuminescenceMacroOp { SSrcId = SSrcId, Luma = BorderLuma };

            if (Mask.HasFlag(MaskFlags.BorderLightSourceDirection))
                yield return new SuperSourceV2ShadowDirectionMacroOp { SSrcId = SSrcId, Direction = BorderLightSourceDirection };

            if (Mask.HasFlag(MaskFlags.BorderLightSourceAltitude))
                yield return new SuperSourceV2ShadowAltitudeMacroOp { SSrcId = SSrcId, Altitude = BorderLightSourceAltitude };
        }
    }
}