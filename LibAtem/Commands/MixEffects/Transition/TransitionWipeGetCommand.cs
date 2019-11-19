using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TWpP", CommandDirection.ToClient, 20)]
    public class TransitionWipeGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), UInt8Range(1, 250)]
        public uint Rate { get; set; }
        [Serialize(2), Enum8]
        public Pattern Pattern { get; set; }
        [Serialize(4), UInt16D(100, 0, 10000)]
        public double BorderWidth { get; set; }
        [Serialize(6), Enum16]
        public VideoSource BorderInput { get; set; }
        [Serialize(8), UInt16D(100, 0, 10000)]
        public double Symmetry { get; set; }
        [Serialize(10), UInt16D(100, 0, 10000)]
        public double BorderSoftness { get; set; }
        [Serialize(12), UInt16D(10000, 0, 10000)]
        public double XPosition { get; set; }
        [Serialize(14), UInt16D(10000, 0, 10000)]
        public double YPosition { get; set; }
        [Serialize(16), Bool]
        public bool ReverseDirection { get; set; }
        [Serialize(17), Bool]
        public bool FlipFlop { get; set; }
    }
}