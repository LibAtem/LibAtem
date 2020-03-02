using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CMLP", CommandDirection.ToServer, 20), NoCommandId]
    public class FairlightMixerMasterLimiterSetCommand : SerializableCommandBase
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
        
        [Serialize(1), Bool]
        public bool LimiterEnabled { get; set; }
        [Serialize(4), Int32D(100, -3000, 0)]
        public double Threshold { get; set; }
        [Serialize(8), Int32D(100, 70, 3000)]
        public double Attack { get; set; }
        [Serialize(12), Int32D(100, 0, 400000)]
        public double Hold { get; set; }
        [Serialize(16), Int32D(100, 5000, 400000)]
        public double Release { get; set; }
    }
}