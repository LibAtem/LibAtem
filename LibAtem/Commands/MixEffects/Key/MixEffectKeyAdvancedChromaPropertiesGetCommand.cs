using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KACk", CommandDirection.ToClient, 24)]
    public class MixEffectKeyAdvancedChromaPropertiesGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        
        [Serialize(2), UInt16D(10, 0, 1000)]
        public double ForegroundLevel { get; set; }
        [Serialize(4), UInt16D(10, 0, 1000)]
        public double BackgroundLevel { get; set; }
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double KeyEdge { get; set; }
        
        [Serialize(8), UInt16D(10, 0, 1000)]
        public double SpillSuppression { get; set; }
        [Serialize(10), UInt16D(10, 0, 1000)]
        public double FlareSuppression { get; set; }
        
        [Serialize(12), Int16D(10, -1000, 1000)]
        public double Brightness { get; set; }
        [Serialize(14), Int16D(10, -1000, 1000)]
        public double Contrast { get; set; }
        [Serialize(16), UInt16D(10, 0, 2000)]
        public double Saturation { get; set; }
        [Serialize(18), Int16D(10, -1000, 1000)]
        public double Red { get; set; }
        [Serialize(20), Int16D(10, -1000, 1000)]
        public double Green { get; set; }
        [Serialize(22), Int16D(10, -1000, 1000)]
        public double Blue { get; set; }
    }
}