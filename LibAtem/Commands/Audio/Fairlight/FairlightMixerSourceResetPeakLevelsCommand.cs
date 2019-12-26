using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("RFIP", CommandDirection.ToServer, 20)]
    public class FairlightMixerSourceResetPeakLevelsCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public AudioSource Index { get; set; }
        [CommandId]
        [Serialize(8), Int64]
        public long SourceId { get; set; }

        [Serialize(17), Bool(2)]
        public bool Output { get; set; }
        [Serialize(17), Bool(0)]
        public bool DynamicsInput{ get; set; }
        [Serialize(17), Bool(1)]
        public bool DynamicsOutput { get; set; }
    }
}