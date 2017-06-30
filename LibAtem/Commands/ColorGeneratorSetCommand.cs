using System;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("CClV", 8)]
    public class ColorGeneratorSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Hue = 1 << 0,
            Saturation = 1 << 1,
            Luma = 1 << 2,
        }
        
        [Serializable(0), Enum8]
        public MaskFlags Mask { get; set; }
        
        [Serializable(1), UInt8Range(0, 1)]
        public uint Index { get; set; }

        [Serializable(2), UInt16D(10, 0, 3599)]
        public double Hue { get; set; }

        [Serializable(4), UInt16D(10, 0, 1000)]
        public double Saturation { get; set; }

        [Serializable(6), UInt16D(10, 0, 1000)]
        public double Luma { get; set; }
    }
}