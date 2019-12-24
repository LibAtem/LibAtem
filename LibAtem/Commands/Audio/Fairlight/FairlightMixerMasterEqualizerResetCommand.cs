using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("RMOE", CommandDirection.ToServer, 4), NoCommandId]
    public class FairlightMixerMasterEqualizerResetCommand : SerializableCommandBase
    {
        // TODO - mask?
        
        [Serialize(1), Bool]
        public bool Equalizer { get; set; }
    }
}