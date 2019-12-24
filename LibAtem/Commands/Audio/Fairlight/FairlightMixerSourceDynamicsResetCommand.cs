using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("RICD", CommandDirection.ToServer, 20)]
    public class FairlightMixerSourceDynamicsResetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public AudioSource Index { get; set; }
        [CommandId]
        [Serialize(8), Int64]
        public long SourceId { get; set; }

        [Serialize(17), Bool(0)]
        public bool Dynamics { get; set; }
        [Serialize(17), Bool(1)]
        public bool Expander { get; set; }
        [Serialize(17), Bool(2)]
        public bool Compressor { get; set; }
        [Serialize(17), Bool(3)]
        public bool Limiter { get; set; }
    }
}