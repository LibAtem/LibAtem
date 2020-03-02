using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FMPP", CommandDirection.ToServer, 4), NoCommandId]
    public class FairlightMixerMasterPropertiesGetCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool AudioFollowVideoCrossfadeTransitionEnabled { get; set; }
    }
}