using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Key;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKDV", 64)]
    public class MixEffectKeyDVESetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            SizeX                = 1 << 0,
            SizeY                = 1 << 1,
            PositionX            = 1 << 2,
            PositionY            = 1 << 3,
            Rotation             = 1 << 4,
            BorderEnabled        = 1 << 5,
            ShadowEnabled        = 1 << 6,
            BorderBevel          = 1 << 7,
            BorderOuterWidth     = 1 << 8,
            BorderInnerWidth     = 1 << 9,
            BorderOuterSoftness  = 1 << 10,
            BorderInnerSoftness  = 1 << 11,
            BorderBevelSoftness  = 1 << 12,
            BorderBevelPosition  = 1 << 13,
            BorderOpacity        = 1 << 14,
            BorderHue            = 1 << 15,
            BorderSaturation     = 1 << 16,
            BorderLuma           = 1 << 17,
            LightSourceDirection = 1 << 18,
            LightSourceAltitude  = 1 << 19,
            MaskEnabled          = 1 << 20,
            MaskTop              = 1 << 21,
            MaskBottom           = 1 << 22,
            MaskLeft             = 1 << 23,
            MaskRight            = 1 << 24,
            Rate                 = 1 << 25,
        }

        [Serialize(0), Enum32]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(4), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(5), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }

        [Serialize(8), Int32D(1000, -100, 100)] // TODO - check range
        public double SizeX { get; set; }
        [Serialize(12), Int32D(1000, -100, 100)] // TODO - check range
        public double SizeY { get; set; }
        [Serialize(16), Int32D(1000, -1000, 1000)] // TODO - check range
        public double PositionX { get; set; }
        [Serialize(20), Int32D(1000, -1000, 1000)] // TODO - check range
        public double PositionY { get; set; }
        [Serialize(24), Int32D(1000, -1000, 1000)] // TODO - check range
        public double Rotation { get; set; }

        [Serialize(28), Bool]
        public bool BorderEnabled { get; set; }
        [Serialize(29), Bool]
        public bool ShadowEnabled { get; set; }
        [Serialize(30), Enum8]
        public BorderBevel BorderBevel { get; set; }
        [Serialize(32), UInt16D(100, 0, 1600)]
        public double OuterWidth { get; set; }
        [Serialize(34), UInt16D(100, 0, 1600)]
        public double InnerWidth { get; set; }
        [Serialize(36), UInt8D(100, 0, 100)]
        public double OuterSoftness { get; set; }
        [Serialize(37), UInt8D(100, 0, 100)]
        public double InnerSoftness { get; set; }
        [Serialize(38), UInt8D(100, 0, 100)]
        public double BevelSoftness { get; set; }
        [Serialize(39), UInt8D(100, 0, 100)]
        public double BevelPosition { get; set; }
        [Serialize(40), UInt8D(100, 0, 100)]
        public double BorderOpacity { get; set; }

        [Serialize(42), UInt16D(1000, 0, 3599)]
        public double BorderHue { get; set; }
        [Serialize(44), UInt16D(1000, 0, 1000)]
        public double BorderSaturation { get; set; }
        [Serialize(46), UInt16D(1000, 0, 1000)]
        public double BorderLuma { get; set; }

        [Serialize(48), UInt16D(10, 0, 3590)]
        public double LightSourceDirection { get; set; }
        [Serialize(50), UInt8Range(10, 100)]
        public uint LightSourceAltitude { get; set; }

        [Serialize(51), Bool]
        public bool MaskEnabled { get; set; }
        [Serialize(52), Int16D(1000, -9000, 9000)]
        public double MaskTop { get; set; }
        [Serialize(54), Int16D(1000, -9000, 9000)]
        public double MaskBottom { get; set; }
        [Serialize(56), Int16D(1000, -16000, 16000)]
        public double MaskLeft { get; set; }
        [Serialize(58), Int16D(1000, -16000, 16000)]
        public double MaskRight { get; set; }

        [Serialize(60), UInt8Range(1, 250)]
        public uint Rate { get; set; }

//        public void Serialize(ByteArrayBuilder cmd)
//        {
//            cmd.Pad(4); // Mask
//            cmd.AddUInt8((int)MixEffectIndex);
//            cmd.AddUInt8(KeyerIndex);
//            cmd.Pad(58);
//        }
//
//        public void Deserialize(ParsedByteArray cmd)
//        {
//            cmd.Skip(4);
//            MixEffectIndex = (MixEffectBlockId)cmd.GetUInt8();
//            KeyerIndex = cmd.GetUInt8();
//            cmd.Skip(58);
//        }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.SizeX))
                yield return new DVEAndFlyKeyXSizeMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, SizeX = SizeX};

            if (Mask.HasFlag(MaskFlags.SizeY))
                yield return new DVEAndFlyKeyYSizeMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, SizeY = SizeY};

            if (Mask.HasFlag(MaskFlags.PositionX))
                yield return new DVEAndFlyKeyXPositionMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, PositionX = PositionX};

            if (Mask.HasFlag(MaskFlags.PositionY))
                yield return new DVEAndFlyKeyYPositionMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, PositionY = PositionY};

            if (Mask.HasFlag(MaskFlags.Rotation))
                yield return new DVEAndFlyKeyRotationMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, Rotation = Rotation};

            if (Mask.HasFlag(MaskFlags.BorderEnabled))
                yield return new DVEKeyBorderEnableMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, Enable = BorderEnabled};

            if (Mask.HasFlag(MaskFlags.ShadowEnabled))
                yield return new DVEKeyShadowEnableMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, Enable = ShadowEnabled};

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

            if (Mask.HasFlag(MaskFlags.BorderOpacity))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderHue))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderSaturation))
                yield return null;

            if (Mask.HasFlag(MaskFlags.BorderLuma))
                yield return null;

            if (Mask.HasFlag(MaskFlags.LightSourceDirection))
                yield return new DVEKeyShadowDirectionMacroOp { Index = MixEffectIndex, KeyIndex = KeyerIndex, Direction = LightSourceDirection };

            if (Mask.HasFlag(MaskFlags.LightSourceAltitude))
                yield return new DVEKeyShadowAltitudeMacroOp {Index = MixEffectIndex, KeyIndex = KeyerIndex, Altitude = LightSourceAltitude};

            if (Mask.HasFlag(MaskFlags.MaskEnabled))
                yield return new DVEKeyMaskEnableMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, Enable = MaskEnabled};

            if (Mask.HasFlag(MaskFlags.MaskTop))
                yield return new DVEKeyMaskTopMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, Top = MaskTop};

            if (Mask.HasFlag(MaskFlags.MaskBottom))
                yield return new DVEKeyMaskBottomMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, Bottom = MaskBottom};

            if (Mask.HasFlag(MaskFlags.MaskLeft))
                yield return new DVEKeyMaskLeftMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, Left = MaskLeft};

            if (Mask.HasFlag(MaskFlags.MaskRight))
                yield return new DVEKeyMaskRightMacroOp() {Index = MixEffectIndex, KeyIndex = KeyerIndex, Right = MaskRight};

            if (Mask.HasFlag(MaskFlags.Rate))
                yield return null;
        }
    }
}