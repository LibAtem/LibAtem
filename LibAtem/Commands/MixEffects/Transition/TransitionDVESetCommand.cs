using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTDv", 20)]
    public class TransitionDVESetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Rate          = 1 << 0,
            LogoRate      = 1 << 1,
            Style         = 1 << 2,
            FillSource    = 1 << 3,
            KeySource     = 1 << 4,
            EnableKey     = 1 << 5,
            PreMultiplied = 1 << 6,
            Clip          = 1 << 7,
            Gain          = 1 << 8,
            InvertKey     = 1 << 9,
            Reverse       = 1 << 10,
            FlipFlop      = 1 << 11,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }

        [Serialize(2), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(3), UInt8Range(1, 250)]
        public uint Rate { get; set; }
        [Serialize(4), UInt8Range(1, 250)]
        public uint LogoRate { get; set; }
        [Serialize(5), Enum8]
        public DVEEffect Style { get; set; }

        [Serialize(6), Enum16]
        public VideoSource FillSource { get; set; }
        [Serialize(8), Enum16]
        public VideoSource KeySource { get; set; }

        [Serialize(10), Bool]
        public bool EnableKey { get; set; }
        [Serialize(11), Bool]
        public bool PreMultiplied { get; set; }
        [Serialize(12), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serialize(14), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(16), Bool]
        public bool InvertKey { get; set; }
        [Serialize(17), Bool]
        public bool Reverse { get; set; }
        [Serialize(18), Bool]
        public bool FlipFlop { get; set; }}
}