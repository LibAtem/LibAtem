using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CACC", CommandDirection.ToServer, 20)]
    public class MixEffectKeyAdvancedChromaSampleSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            EnableCursor = 1 << 0,
            Preview = 1 << 1,
            CursorX = 1 << 2,
            CursorY = 1 << 3,
            CursorSize = 1 << 4,
            SampledY = 1 << 5,
            SampledCb = 1 << 6,
            SampledCr = 1 << 7,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(2), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        
        [Serialize(3), Bool]
        public bool EnableCursor { get; set; }
        [Serialize(4), Bool]
        public bool Preview { get; set; }
        [Serialize(6), Int16D(1000, -15383, 15383)]
        public double CursorX { get; set; }
        [Serialize(8), Int16D(1000, -8383, 8383)]
        public double CursorY { get; set; }
        [Serialize(10), UInt16D(100, 625, 9925)]
        public double CursorSize { get; set; }
        
        [Serialize(12), UInt16D(10000, 0, 10000)]
        public double SampledY { get; set; }
        [Serialize(14), Int16D(10000, 0, 10000)]
        public double SampledCb { get; set; }
        [Serialize(16), Int16D(10000, 0, 10000)]
        public double SampledCr { get; set; }
    }
}