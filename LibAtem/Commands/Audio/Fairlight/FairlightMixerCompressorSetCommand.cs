using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CICP", CommandDirection.ToServer, 40)]
    public class FairlightMixerCompressorSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            CompressorEnabled = 1 << 0,
            Threshold = 1 << 1,
            Ratio = 1 << 2,
            Attack = 1 << 3,
            Hold = 1 << 4,
            Release = 1 << 5,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public AudioSource Index { get; set; }
        
        [Serialize(16), Bool]
        public bool CompressorEnabled { get; set; }
        [Serialize(20), Int32D(100, -5000, 0)]
        public double Threshold { get; set; }
        [Serialize(24), Int16D(100, 120, 2000)]
        public double Ratio { get; set; }
        [Serialize(28), Int32D(100, 70, 10000)]
        public double Attack { get; set; }
        [Serialize(32), Int32D(100, 0, 400000)]
        public double Hold { get; set; }
        [Serialize(36), Int32D(100, 5000, 400000)]
        public double Release { get; set; }
    }
}