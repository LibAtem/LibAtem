using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("RICE", CommandDirection.ToServer, 20)]
    public class FairlightMixerSourceEqualizerResetCommand : SerializableCommandBase
    {
        // TODO - mask?

        [CommandId]
        [Serialize(2), Enum16]
        public AudioSource Index { get; set; }
        [CommandId]
        [Serialize(8), Int64]
        public long SourceId { get; set; }

        [Serialize(16), Bool]
        public bool Equalizer { get; set; }
    }
}