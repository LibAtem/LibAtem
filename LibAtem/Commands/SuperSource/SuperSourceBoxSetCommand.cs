using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.SuperSource;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("CSBP", 24)]
    public class SuperSourceBoxSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Enabled = 1 << 0,
            Source = 1 << 1,
            PositionX = 1 << 2,
            PositionY = 1 << 3,
            Size = 1 << 4,
            Cropped = 1 << 5,
            CropTop = 1 << 6,
            CropBottom = 1 << 7,
            CropLeft = 1 << 8,
            CropRight = 1 << 9,
        }
        
        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(2), Enum8]
        public SuperSourceBoxId Index { get; set; }
        
        [Serialize(3), Bool]
        public bool Enabled { get; set; }
        
        [Serialize(4), Enum16]
        public VideoSource InputSource { get; set; }
        
        [Serialize(6), Int16D(100, -4800, 4800)]
        public double PositionX { get; set; }
        
        [Serialize(8), Int16D(100, -3400, 3400)]
        public double PositionY { get; set; }
        
        [Serialize(10), UInt16D(1000, 70, 1000)]
        public double Size { get; set; }
        
        [Serialize(12), Bool]
        public bool Cropped { get; set; }

        [Serialize(14), UInt16D(1000, 0, 18000)]
        public double CropTop { get; set; }
        
        [Serialize(16), UInt16D(1000, 0, 18000)]
        public double CropBottom { get; set; }

        [Serialize(18), UInt16D(1000, 0, 32000)]
        public double CropLeft { get; set; }
        
        [Serialize(20), UInt16D(1000, 0, 32000)]
        public double CropRight { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Enabled))
                yield return new SuperSourceBoxEnableMacroOp() {BoxIndex = Index, Enable = Enabled};

            if (Mask.HasFlag(MaskFlags.Source))
                yield return new SuperSourceBoxInputMacroOp() {BoxIndex = Index, Source = InputSource};

            if (Mask.HasFlag(MaskFlags.PositionX))
                yield return new SuperSourceBoxXPositionMacroOp() {BoxIndex = Index, PositionX = PositionX};

            if (Mask.HasFlag(MaskFlags.PositionY))
                yield return new SuperSourceBoxYPositionMacroOp() {BoxIndex = Index, PositionY = PositionY};

            if (Mask.HasFlag(MaskFlags.Size))
                yield return new SuperSourceBoxSizeMacroOp() {BoxIndex = Index, Size = Size};

            if (Mask.HasFlag(MaskFlags.Cropped))
                yield return new SuperSourceBoxMaskEnableMacroOp() {BoxIndex = Index, Enable = Cropped};

            if (Mask.HasFlag(MaskFlags.CropTop))
                yield return new SuperSourceBoxMaskTopMacroOp() {BoxIndex = Index, Top = CropTop};

            if (Mask.HasFlag(MaskFlags.CropBottom))
                yield return new SuperSourceBoxMaskBottomMacroOp() {BoxIndex = Index, Bottom = CropBottom};

            if (Mask.HasFlag(MaskFlags.CropLeft))
                yield return new SuperSourceBoxMaskLeftMacroOp() {BoxIndex = Index, Left = CropLeft};

            if (Mask.HasFlag(MaskFlags.CropRight))
                yield return new SuperSourceBoxMaskRightMacroOp() {BoxIndex = Index, Right = CropRight};
        }
    }
}