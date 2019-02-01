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
        [Serialize(7), Enum8]
        public AudioPortType PortType { get; set; }
        [Serialize(8), Enum8]
        public AudioMixOption MixOption { get; set; }
        [Serialize(10), Decibels]
        public double Gain { get; set; }
        [Serialize(12), Int16D(200, -10000, 10000)]
        public double Balance { get; set; }

        [Serialize(4), Enum16]
        protected AudioSource Index2 => Index;
        [Serialize(6), Bool]
        protected bool Unknown => false;
        [Serialize(9), UInt8]
        protected uint Unknown2 => 0x73;

        public override void Serialize(ByteArrayBuilder cmd)
        {
            base.Serialize(cmd);

            // TODO - replace the above protected props with overrides in here
        }
    }
}