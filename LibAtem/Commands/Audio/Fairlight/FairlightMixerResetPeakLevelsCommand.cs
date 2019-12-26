using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("RFLP", CommandDirection.ToServer, 4), NoCommandId]
    public class FairlightMixerResetPeakLevelsCommand : SerializableCommandBase
    {
        [Serialize(0), Bool(0)]
        public bool All { get; set; }

        [Serialize(0), Bool(1)]
        public bool Master { get; set; }
    }
}