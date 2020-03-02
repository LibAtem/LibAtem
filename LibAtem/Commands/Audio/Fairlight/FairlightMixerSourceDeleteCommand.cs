using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FASD", CommandDirection.ToClient, 16)]
    public class FairlightMixerSourceDeleteCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public AudioSource Index { get; set; }

        [CommandId]
        [Serialize(8), Int64]
        public long SourceId { get; set; }

    }
}