using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMmO", CommandDirection.ToClient, 12), NoCommandId]
    public class AudioMixerMonitorGetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool Enabled { get; set; }
        [Serialize(2), Decibels]
        public double Gain { get; set; }
        [Serialize(4), Bool]
        public bool Mute { get; set; }
        [Serialize(5), Bool]
        public bool Solo { get; set; }
        [Serialize(6), Enum16]
        public AudioSource SoloSource { get; set; }
        [Serialize(8), Bool]
        public bool Dim { get; set; }
        [Serialize(10), UInt16D(100, 0, 10000)]
        public double DimLevel { get; set; }
    }
}