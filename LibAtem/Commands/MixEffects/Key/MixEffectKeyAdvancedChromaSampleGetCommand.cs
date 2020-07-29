using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KACC", CommandDirection.ToClient, 16)]
    public class MixEffectKeyAdvancedChromaSampleGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        
        [Serialize(2), Bool]
        public bool EnableCursor { get; set; }
        [Serialize(3), Bool]
        public bool Preview { get; set; }
        [Serialize(4), Int16D(1000, -15383, 15383)]
        public double CursorX { get; set; }
        [Serialize(6), Int16D(1000, -8383, 8383)]
        public double CursorY { get; set; }
        [Serialize(8), UInt16D(100, 620, 9925)]
        public double CursorSize { get; set; }
        
        [Serialize(10), UInt16D(10000, 0, 10000)]
        public double SampledY { get; set; }
        [Serialize(12), Int16D(10000, 0, 10000)]
        public double SampledCb { get; set; }
        [Serialize(14), Int16D(10000, 0, 10000)]
        public double SampledCr { get; set; }
    }
}