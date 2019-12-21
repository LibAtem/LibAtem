using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FAMP", CommandDirection.ToClient, 20), NoCommandId]
    public class FairlightMixerMasterGetCommand : SerializableCommandBase
    {
        [Serialize(1), Bool]
        public bool EqualizerEnabled { get; set; }
        [Serialize(4), Int32D(100, -2000, 2000)]
        public double EqualizerGain { get; set; }
        [Serialize(8), Int32D(100, 0, 2000)]
        public double MakeUpGain { get; set; }
        [Serialize(12), Int32D(100, -12041, 600)]
        public double Gain { get; set; }
        [Serialize(16), Bool]
        public bool FollowFadeToBlack { get; set; }
    }
}