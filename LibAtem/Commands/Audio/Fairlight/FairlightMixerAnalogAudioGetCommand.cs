using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FAAI", CommandDirection.ToClient, 4)]
    public class FairlightMixerAnalogAudioGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public AudioSource Index { get; set; }

        [Serialize(2), Enum8]
        public FairlightAnalogInputLevel SupportedInputLevel { get; set; }
        [Serialize(3), Enum8]
        public FairlightAnalogInputLevel InputLevel { get; set; }
    }
}