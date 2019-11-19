using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMIP", 20)]
    public class AudioMixerInputGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public AudioSource Index { get; set; }
        [Serialize(2), Enum8]
        public AudioSourceType SourceType { get; set; }

        [Serialize(4), UInt16]
        public uint IndexOfSourceType { get; set; } // Looks like it

        [Serialize(6), Enum16]
        public AudioPortType PortType { get; set; }
        [Serialize(8), Enum8]
        public AudioMixOption MixOption { get; set; }
        [Serialize(10), Decibels]
        public double Gain { get; set; }
        [Serialize(12), Int16D(200, -10000, 10000)]
        public double Balance { get; set; }
    }
}