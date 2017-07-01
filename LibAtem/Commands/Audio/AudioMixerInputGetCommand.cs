using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMIP", 20)]
    public class AudioMixerInputGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum16]
        public AudioSource Index { get; set; }
        [Serializable(2), Enum8]
        public AudioSourceType SourceType { get; set; }
        [Serializable(7), Enum8]
        public AudioPortType PortType { get; set; }
        [Serializable(8), Enum8]
        public AudioMixOption MixOption { get; set; }
        [Serializable(10), Decibels]
        public double Gain { get; set; }
        [Serializable(12), Int16D(200, -10000, 10000)]
        public double Balance { get; set; }

        [Serializable(4), Enum16]
        protected AudioSource Index2 => Index;
        [Serializable(6), Bool]
        protected bool Unknown => false;
        [Serializable(9), UInt8]
        protected uint Unknown2 => 0x73;

        public override void Serialize(CommandBuilder cmd)
        {
            base.Serialize(cmd);

            // TODO - replace the above protected props with overrides in here
        }
    }
}