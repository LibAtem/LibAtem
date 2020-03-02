using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CACK", CommandDirection.ToServer, 28)]
    public class MixEffectKeyAdvancedChromaPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            ForegroundLevel = 1 << 0,
            BackgroundLevel = 1 << 1,
            KeyEdge = 1 << 2,
            SpillSuppression = 1 << 3,
            FlareSuppression = 1 << 4,
            Brightness = 1 << 5,
            Contrast = 1 << 6,
            Saturation = 1 << 7,
            Red = 1 << 8,
            Green = 1 << 9,
            Blue = 1 << 10,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }
        
        [CommandId]
        [Serialize(2), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(3), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        
        [Serialize(4), UInt16D(10, 0, 1000)]
        public double ForegroundLevel { get; set; }
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double BackgroundLevel { get; set; }
        [Serialize(8), UInt16D(10, 0, 1000)]
        public double KeyEdge { get; set; }
        
        [Serialize(10), UInt16D(10, 0, 1000)]
        public double SpillSuppression { get; set; }
        [Serialize(12), UInt16D(10, 0, 1000)]
        public double FlareSuppression { get; set; }
        
        [Serialize(14), Int16D(10, -1000, 1000)]
        public double Brightness { get; set; }
        [Serialize(16), Int16D(10, -1000, 1000)]
        public double Contrast { get; set; }
        [Serialize(18), UInt16D(10, 0, 2000)]
        public double Saturation { get; set; }
        [Serialize(20), Int16D(10, -1000, 1000)]
        public double Red { get; set; }
        [Serialize(22), Int16D(10, -1000, 1000)]
        public double Green { get; set; }
        [Serialize(24), Int16D(10, -1000, 1000)]
        public double Blue { get; set; }
    }
}