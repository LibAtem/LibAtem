using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FMHP", CommandDirection.ToServer, 32), NoCommandId]
    public class FairlightMixerMonitorGetCommand : SerializableCommandBase
    {
        [Serialize(0), Int32D(100, -12141, 600)]
        public double Gain { get; set; }
        [Serialize(4), Int32D(100, -6000, 600)]
        public double InputMasterGain { get; set; }
        [Serialize(12), Int32D(100, -6000, 600)]
        public double InputTalkbackGain { get; set; }
        [Serialize(28), Int32D(100, -6000, 600)]
        public double InputSidetoneGain { get; set; }
    }
}