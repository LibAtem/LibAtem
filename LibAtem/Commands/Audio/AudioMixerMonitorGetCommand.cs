using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMmO", 12)]
    public class AudioMixerMonitorGetCommand : SerializableCommandBase
    {
        [Serializable(0), Bool]
        public bool Enabled { get; set; }
        [Serializable(2), Decibels]
        public double Gain { get; set; }
        [Serializable(4), Bool]
        public bool Mute { get; set; }
        [Serializable(5), Bool]
        public bool Solo { get; set; }
        [Serializable(6), Enum16]
        public AudioSource SoloSource { get; set; }
        [Serializable(8), Bool]
        public bool Dim { get; set; }
    }
}