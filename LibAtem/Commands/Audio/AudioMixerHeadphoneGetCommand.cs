using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMHP", CommandDirection.ToClient, 8), NoCommandId]
    public class AudioMixerHeadphoneGetCommand : SerializableCommandBase
    {
        [Serialize(0), Decibels]
        public double Gain { get; set; }
        [Serialize(2), Decibels]
        public double ProgramOutGain { get; set; }
        [Serialize(4), Decibels]
        public double TalkbackGain { get; set; }
        [Serialize(6), Decibels]
        public double SidetoneGain { get; set; }
    }
}