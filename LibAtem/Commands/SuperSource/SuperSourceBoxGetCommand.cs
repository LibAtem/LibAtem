using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.SuperSource
{
    [CommandName("SSBP", 20)]
    public class SuperSourceBoxGetCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8Range(0, 3)]
        public uint Index { get; set; }
        
        [Serializable(1), Bool]
        public bool Enabled { get; set; }
        
        [Serializable(2), Enum16]
        public VideoSource InputSource { get; set; }
        
        [Serializable(4), Int16D(100, -4800, 4800)]
        public double PositionX { get; set; }
        
        [Serializable(6), Int16D(100, -4800, 4800)]
        public double PositionY { get; set; }
        
        [Serializable(8), UInt16D(1000, 70, 1000)]
        public double Size { get; set; }
        
        [Serializable(10), Bool]
        public bool Cropped { get; set; }

        [Serializable(12), UInt16D(1000, 0, 18000)]
        public double CropTop { get; set; }
        
        [Serializable(14), UInt16D(1000, 0, 18000)]
        public double CropBottom { get; set; }
        
        [Serializable(16), UInt16D(1000, 0, 32000)]
        public double CropLeft { get; set; }

        [Serializable(18), UInt16D(1000, 0, 32000)]
        public double CropRight { get; set; }
    }
}