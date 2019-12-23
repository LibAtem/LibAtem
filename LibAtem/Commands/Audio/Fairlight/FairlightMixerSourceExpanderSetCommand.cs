using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CIXP", CommandDirection.ToServer, 40)]
    public class FairlightMixerSourceExpanderSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            ExpanderEnabled = 1 << 0,
            GateEnabled = 1 << 1,
            Threshold = 1 << 2,
            Range = 1 << 3,
            Ratio = 1 << 4,
            Attack = 1 << 5,
            Hold = 1 << 6,
            Release = 1 << 7,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public AudioSource Index { get; set; }
        [CommandId]
        [Serialize(8), Int64]
        public long SourceId { get; set; }

        [Serialize(16), Bool]
        public bool ExpanderEnabled { get; set; }
        [Serialize(17), Bool]
        public bool GateEnabled { get; set; }
        [Serialize(20), Int32D(100, -5000, 0)]
        public double Threshold { get; set; }
        [Serialize(24), Int16D(100, 0, 6000)]
        public double Range { get; set; }
        [Serialize(26), Int16D(100, 110, 300)]
        public double Ratio { get; set; }
        [Serialize(28), Int32D(100, 50, 10000)]
        public double Attack { get; set; }
        [Serialize(32), Int32D(100, 0, 400000)]
        public double Hold { get; set; }
        [Serialize(36), Int32D(100, 5000, 400000)]
        public double Release { get; set; }
    }
}