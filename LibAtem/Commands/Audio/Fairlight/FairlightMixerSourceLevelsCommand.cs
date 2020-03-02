using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FMLv", CommandDirection.ToClient, 40)]
    public class FairlightMixerSourceLevelsCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Int64]
        public long SourceId { get; set; }
        [CommandId]
        [Serialize(8), Enum16]
        public AudioSource Index { get; set; }

        [Serialize(10), Int16D(100, -10000, 0)]
        public double InputLeftLevel { get; set; }
        [Serialize(12), Int16D(100, -10000, 0)]
        public double InputRightLevel { get; set; }
        [Serialize(14), Int16D(100, -10000, 0)]
        public double InputLeftPeak { get; set; }
        [Serialize(16), Int16D(100, -10000, 0)]
        public double InputRightPeak { get; set; }

        [Serialize(18), Int16D(100, -10000, 0)]
        public double ExpanderGainReduction { get; set; }
        [Serialize(20), Int16D(100, -10000, 0)]
        public double CompressorGainReduction { get; set; }
        [Serialize(22), Int16D(100, -10000, 0)]
        public double LimiterGainReduction { get; set; }

        [Serialize(24), Int16D(100, -10000, 0)]
        public double OutputLeftLevel { get; set; }
        [Serialize(26), Int16D(100, -10000, 0)]
        public double OutputRightLevel { get; set; }
        [Serialize(28), Int16D(100, -10000, 0)]
        public double OutputLeftPeak { get; set; }
        [Serialize(30), Int16D(100, -10000, 0)]
        public double OutputRightPeak { get; set; }

        [Serialize(32), Int16D(100, -10000, 0)]
        public double LeftLevel { get; set; }
        [Serialize(34), Int16D(100, -10000, 0)]
        public double RightLevel { get; set; }
        [Serialize(36), Int16D(100, -10000, 0)]
        public double LeftPeak { get; set; }
        [Serialize(38), Int16D(100, -10000, 0)]
        public double RightPeak { get; set; }
    }
}