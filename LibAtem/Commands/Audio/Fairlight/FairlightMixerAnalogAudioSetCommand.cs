using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CFAA", CommandDirection.ToServer, 4)]
    public class FairlightMixerAnalogAudioSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public AudioSource Index { get; set; }
        
        [Serialize(2), Enum8]
        public FairlightAnalogSourceType Type { get; set; }
    }
}