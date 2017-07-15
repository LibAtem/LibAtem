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
        
        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(2), UInt8Range(0, 3)]
        public uint Index { get; set; }
        
        [Serialize(3), Bool]
        public bool Enabled { get; set; }
        
        [Serialize(4), Enum16]
        public VideoSource InputSource { get; set; }
        
        [Serialize(6), Int16D(100, -4800, 4800)]
        public double PositionX { get; set; }
        
        [Serialize(8), Int16D(100, -4800, 4800)]
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
    }
}