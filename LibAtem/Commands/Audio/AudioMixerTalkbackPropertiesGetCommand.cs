using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("ATMP", CommandDirection.ToClient, 4), NoCommandId]
    public class AudioMixerTalkbackPropertiesGetCommand : SerializableCommandBase
    {
        [Serialize(1), Bool]
        public bool MuteSDI { get; set; }
    }

}