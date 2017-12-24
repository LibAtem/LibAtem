using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("SALN", 4), NoCommandId]
    public class AudioMixerSendLevelsCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool SendLevels { get; set; }
    }
}