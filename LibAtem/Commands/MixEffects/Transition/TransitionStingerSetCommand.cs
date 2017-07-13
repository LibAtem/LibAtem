using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTSt", 20)]
    public class TransitionStingerSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Source           = 1 << 0,
            PreMultipliedKey = 1 << 1,
            Clip             = 1 << 2,
            Gain             = 1 << 3,
            Invert           = 1 << 4,
            Preroll          = 1 << 5,
            ClipDuration     = 1 << 6,
            TriggerPoint     = 1 << 7,
            MixRate          = 1 << 8,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }
        [Serialize(2), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(3), Enum8]
        public StingerSource Source { get; set; }
        [Serialize(4), Bool]
        public bool PreMultipliedKey { get; set; }

        [Serialize(6), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serialize(8), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(10), Bool]
        public bool Invert { get; set; }

        [Serialize(12), UInt16]
        public uint Preroll { get; set; }
        [Serialize(14), UInt16]
        public uint ClipDuration { get; set; }
        [Serialize(16), UInt16]
        public uint TriggerPoint { get; set; }
        [Serialize(18), UInt16]
        public uint MixRate { get; set; }
    }
}