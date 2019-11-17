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
            Enabled = 1 << 0,
            Bevel = 1 << 1,
            OuterWidth = 1 << 2,
            InnerWidth = 1 << 3,
            OuterSoftness = 1 << 4,
            InnerSoftness = 1 << 5,
            BevelSoftness = 1 << 6,
            BevelPosition = 1 << 7,
            Hue = 1 << 8,
            Saturation = 1 << 9,
            Luma = 1 << 10,
            LightSourceDirection = 1 << 11,
            LightSourceAltitude = 1 << 12,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(2), Enum8]
        public SuperSourceId SSrcId { get; set; }

        [Serialize(3), Bool]
        public bool Enabled { get; set; }
        [Serialize(4), Enum8]
        public BorderBevel Bevel { get; set; }
        [Serialize(6), UInt16D(100, 0, 1600)]
        public double OuterWidth { get; set; }
        [Serialize(8), UInt16D(100, 0, 1600)]
        public double InnerWidth { get; set; }
        [Serialize(10), UInt8Range(0, 100)]
        public uint OuterSoftness { get; set; }
        [Serialize(11), UInt8Range(0, 100)]
        public uint InnerSoftness { get; set; }
        [Serialize(12), UInt8Range(0, 100)]
        public uint BevelSoftness { get; set; }
        [Serialize(13), UInt8Range(0, 100)]
        public uint BevelPosition { get; set; }
        [Serialize(14), UInt16D(10, 0, 3599)]
        public double Hue { get; set; }
        [Serialize(16), UInt16D(10, 0, 1000)]
        public double Saturation { get; set; }
        [Serialize(18), UInt16D(10, 0, 1000)]
        public double Luma { get; set; }
        [Serialize(20), UInt16D(10, 0, 3599)]
        public double LightSourceDirection { get; set; }
        [Serialize(22), UInt8Range(0, 100)]
        public uint LightSourceAltitude { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            if (Mask.HasFlag(MaskFlags.Enabled))
                yield return new SuperSourceV2BorderEnableMacroOp() { SSrcId = SSrcId, Enable = Enabled };

            if (Mask.HasFlag(MaskFlags.Bevel))
                yield return new SuperSourceV2BorderBevelMacroOp { SSrcId = SSrcId, Bevel = Bevel };

            if (Mask.HasFlag(MaskFlags.OuterWidth))
                yield return new SuperSourceV2BorderOuterWidthMacroOp { SSrcId = SSrcId, OuterWidth = OuterWidth };

            if (Mask.HasFlag(MaskFlags.InnerWidth))
                yield return new SuperSourceV2BorderInnerWidthMacroOp { SSrcId = SSrcId, InnerWidth = InnerWidth };

            if (Mask.HasFlag(MaskFlags.OuterSoftness))
                yield return new SuperSourceV2BorderOuterSoftnessMacroOp { SSrcId = SSrcId, OuterSoftness = OuterSoftness };

            if (Mask.HasFlag(MaskFlags.InnerSoftness))
                yield return new SuperSourceV2BorderInnerSoftnessMacroOp { SSrcId = SSrcId, InnerSoftness = InnerSoftness };

            if (Mask.HasFlag(MaskFlags.BevelSoftness))
                yield return new SuperSourceV2BorderBevelSoftnessMacroOp { SSrcId = SSrcId, BevelSoftness = BevelSoftness };

            if (Mask.HasFlag(MaskFlags.BevelPosition))
                yield return new SuperSourceV2BorderBevelPositionMacroOp { SSrcId = SSrcId, BevelPosition = BevelPosition };

            if (Mask.HasFlag(MaskFlags.Hue))
                yield return new SuperSourceV2BorderHueMacroOp { SSrcId = SSrcId, Hue = Hue };

            if (Mask.HasFlag(MaskFlags.Saturation))
                yield return new SuperSourceV2BorderSaturationMacroOp { SSrcId = SSrcId, Saturation = Saturation };

            if (Mask.HasFlag(MaskFlags.Luma))
                yield return new SuperSourceV2BorderLuminescenceMacroOp { SSrcId = SSrcId, Luma = Luma };

            if (Mask.HasFlag(MaskFlags.LightSourceDirection))
                yield return new SuperSourceV2ShadowDirectionMacroOp { SSrcId = SSrcId, Direction = LightSourceDirection };

            if (Mask.HasFlag(MaskFlags.LightSourceAltitude))
                yield return new SuperSourceV2ShadowAltitudeMacroOp { SSrcId = SSrcId, Altitude = LightSourceAltitude };
        }
    }
}