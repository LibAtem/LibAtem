using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTWp", 20)]
    public class TransitionWipeSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Rate = 1 << 0,
            Pattern = 1 << 1,
            BorderWidth = 1 << 2,
            BorderInput = 1 << 3,
            Symmetry = 1 << 4,
            BorderSoftness = 1 << 5,
            XPosition = 1 << 6,
            YPosition = 1 << 7,
            ReverseDirection = 1 << 8,
            FlipFlop = 1 << 9,
        }

        [Serializable(0), Enum16]
        public MaskFlags Mask { get; set; }
        [Serializable(2), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(3), UInt8Range(1, 250)]
        public uint Rate { get; set; }
        [Serializable(4), Enum8]
        public Pattern Pattern { get; set; }
        [Serializable(6), UInt16D(100, 0, 10000)]
        public double BorderWidth { get; set; }
        [Serializable(8), Enum16]
        public VideoSource BorderInput { get; set; }
        [Serializable(10), UInt16D(100, 0, 10000)]
        public double Symmetry { get; set; }
        [Serializable(12), UInt16D(100, 0, 10000)]
        public double BorderSoftness { get; set; }
        [Serializable(14), UInt16D(10000, 0, 10000)]
        public double XPosition { get; set; }
        [Serializable(16), UInt16D(10000, 0, 10000)]
        public double YPosition { get; set; }
        [Serializable(18), Bool]
        public bool ReverseDirection { get; set; }
        [Serializable(19), Bool]
        public bool FlipFlop { get; set; }
    }
}