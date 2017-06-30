using System;
using LibAtem.Common;
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
        
        [Serializable(0), Enum16]
        public MaskFlags Mask { get; set; }
        
        [Serializable(2), UInt8Range(0, 3)]
        public uint Index { get; set; }
        
        [Serializable(3), Bool]
        public bool Enabled { get; set; }
        
        [Serializable(4), Enum16]
        public VideoSource InputSource { get; set; }
        
        [Serializable(6), Int16D(100, -4800, 4800)]
        public double PositionX { get; set; }
        
        [Serializable(8), Int16D(100, -4800, 4800)]
        public double PositionY { get; set; }
        
        [Serializable(10), UInt16D(1000, 70, 1000)]
        public double Size { get; set; }
        
        [Serializable(12), Bool]
        public bool Cropped { get; set; }

        [Serializable(14), UInt16D(1000, 0, 18000)]
        public double CropTop { get; set; }
        
        [Serializable(16), UInt16D(1000, 0, 18000)]
        public double CropBottom { get; set; }

        [Serializable(18), UInt16D(1000, 0, 32000)]
        public double CropLeft { get; set; }
        
        [Serializable(20), UInt16D(1000, 0, 32000)]
        public double CropRight { get; set; }
    }
}