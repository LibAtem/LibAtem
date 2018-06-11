using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMTP", 4), NoCommandId]
    public class AudioMixerTalkbackPropertiesGetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool MuteSDI { get; set; }
    }

}