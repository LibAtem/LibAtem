using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TStP", 20)]
    public class TransitionStingerGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), Enum8]
        public StingerSource Source { get; set; }
        [Serialize(2), Bool]
        public bool PreMultipliedKey { get; set; }

        [Serialize(4), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(8), Bool]
        public bool Invert { get; set; }

        [Serialize(10), UInt16]
        public uint Preroll { get; set; }
        [Serialize(12), UInt16]
        public uint ClipDuration { get; set; }
        [Serialize(14), UInt16]
        public uint TriggerPoint { get; set; }
        [Serialize(16), UInt16]
        public uint MixRate { get; set; }
    }
}