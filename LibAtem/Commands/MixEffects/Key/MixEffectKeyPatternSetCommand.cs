using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKPt", 16)]
    public class MixEffectKeyPatternSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Pattern = 1 << 0,
            Size = 1 << 1,
            Symmetry = 1 << 2,
            Softness = 1 << 3,
            XPosition = 1 << 4,
            YPosition = 1 << 5,
            Inverse = 1 << 6,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(2), UInt8]
        public uint KeyerIndex { get; set; }
        [Serialize(3), Enum8]
        public Pattern Pattern { get; set; }
        [Serialize(4), UInt16D(100, 0, 10000)]
        public double Size { get; set; }
        [Serialize(6), UInt16D(100, 0, 10000)]
        public double Symmetry { get; set; }
        [Serialize(8), UInt16D(100, 0, 10000)]
        public double Softness { get; set; }
        [Serialize(10), UInt16D(10000, 0, 10000)]
        public double XPosition { get; set; }
        [Serialize(12), UInt16D(10000, 0, 10000)]
        public double YPosition { get; set; }
        [Serialize(14), Bool]
        public bool Inverse { get; set; }
    }
}