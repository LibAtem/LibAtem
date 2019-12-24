using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("RMOD", CommandDirection.ToServer, 4)]
    public class FairlightMixerMasterDynamicsResetCommand : SerializableCommandBase
    {
        [Serialize(1), Bool(0)]
        public bool Dynamics { get; set; }
        [Serialize(1), Bool(1)]
        public bool Expander { get; set; }
        [Serialize(1), Bool(2)]
        public bool Compressor { get; set; }
        [Serialize(1), Bool(3)]
        public bool Limiter { get; set; }
    }
}