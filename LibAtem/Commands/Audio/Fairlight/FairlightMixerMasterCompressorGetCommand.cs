using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("MOCP", CommandDirection.ToClient, 24), NoCommandId]
    public class FairlightMixerMasterCompressorGetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool CompressorEnabled { get; set; }
        [Serialize(4), Int32D(100, -5000, 0)]
        public double Threshold { get; set; }
        [Serialize(8), Int16D(100, 120, 2000)]
        public double Ratio { get; set; }
        [Serialize(12), Int32D(100, 70, 10000)]
        public double Attack { get; set; }
        [Serialize(16), Int32D(100, 0, 400000)]
        public double Hold { get; set; }
        [Serialize(20), Int32D(100, 5000, 400000)]
        public double Release { get; set; }
    }
}