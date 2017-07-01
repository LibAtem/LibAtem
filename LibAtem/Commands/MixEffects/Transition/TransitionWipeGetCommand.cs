using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TWpP", 20)]
    public class TransitionWipeGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(1), UInt8Range(1, 250)]
        public uint Rate { get; set; }
        [Serializable(2), Enum8]
        public Pattern Pattern { get; set; }
        [Serializable(4), UInt16D(100, 0, 10000)]
        public double BorderWidth { get; set; }
        [Serializable(6), Enum16]
        public VideoSource BorderInput { get; set; }
        [Serializable(8), UInt16D(100, 0, 10000)]
        public double Symmetry { get; set; }
        [Serializable(10), UInt16D(100, 0, 10000)]
        public double BorderSoftness { get; set; }
        [Serializable(12), UInt16D(10000, 0, 10000)]
        public double XPosition { get; set; }
        [Serializable(14), UInt16D(10000, 0, 10000)]
        public double YPosition { get; set; }
        [Serializable(16), Bool]
        public bool ReverseDirection { get; set; }
        [Serializable(17), Bool]
        public bool FlipFlop { get; set; }
    }
}