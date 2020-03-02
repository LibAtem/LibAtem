using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FDLv", CommandDirection.ToClient, 28), NoCommandId]
    public class FairlightMixerMasterLevelsCommand : SerializableCommandBase
    {
        [Serialize(0), Int16D(100, -10000, 0)]
        public double InputLeftLevel { get; set; }
        [Serialize(2), Int16D(100, -10000, 0)]
        public double InputRightLevel { get; set; }
        [Serialize(4), Int16D(100, -10000, 0)]
        public double InputLeftPeak { get; set; }
        [Serialize(6), Int16D(100, -10000, 0)]
        public double InputRightPeak { get; set; }

        [Serialize(8), Int16D(100, -10000, 0)]
        public double CompressorGainReduction { get; set; }
        [Serialize(10), Int16D(100, -10000, 0)]
        public double LimiterGainReduction { get; set; }

        [Serialize(12), Int16D(100, -10000, 0)]
        public double OutputLeftLevel { get; set; }
        [Serialize(14), Int16D(100, -10000, 0)]
        public double OutputRightLevel { get; set; }
        [Serialize(16), Int16D(100, -10000, 0)]
        public double OutputLeftPeak { get; set; }
        [Serialize(18), Int16D(100, -10000, 0)]
        public double OutputRightPeak { get; set; }

        [Serialize(20), Int16D(100, -10000, 0)]
        public double LeftLevel { get; set; }
        [Serialize(22), Int16D(100, -10000, 0)]
        public double RightLevel { get; set; }
        [Serialize(24), Int16D(100, -10000, 0)]
        public double LeftPeak { get; set; }
        [Serialize(26), Int16D(100, -10000, 0)]
        public double RightPeak { get; set; }
    }
}