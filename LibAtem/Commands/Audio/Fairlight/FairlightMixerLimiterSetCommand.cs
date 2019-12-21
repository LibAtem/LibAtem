using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CILP", CommandDirection.ToServer, 36)]
    public class FairlightMixerLimiterSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            LimiterEnabled = 1 << 0,
            Threshold = 1 << 1,
            Attack = 1 << 2,
            Hold = 1 << 3,
            Release = 1 << 4,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public AudioSource Index { get; set; }
        
        [Serialize(16), Bool]
        public bool LimiterEnabled { get; set; }
        [Serialize(20), Int32D(100, -3000, 0)]
        public double Threshold { get; set; }
        [Serialize(24), Int32D(100, 70, 3000)]
        public double Attack { get; set; }
        [Serialize(28), Int32D(100, 0, 400000)]
        public double Hold { get; set; }
        [Serialize(32), Int32D(100, 5000, 400000)]
        public double Release { get; set; }
    }
}