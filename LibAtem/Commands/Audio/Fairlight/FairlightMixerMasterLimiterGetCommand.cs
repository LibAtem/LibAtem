using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("AMLP", CommandDirection.ToClient, 20), NoCommandId]
    public class FairlightMixerMasterLimiterGetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
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