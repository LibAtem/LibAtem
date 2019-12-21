using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("SFLN", CommandDirection.ToServer, 4), NoCommandId]
    public class FairlightMixerSendLevelsCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool SendLevels { get; set; }
    }
}