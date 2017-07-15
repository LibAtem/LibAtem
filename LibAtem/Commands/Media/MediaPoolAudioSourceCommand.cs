using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("MPAS", 84)]
    public class MediaPoolAudioSourceCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint Index { get; set; }
        [Serialize(1), Bool]
        public bool IsUsed { get; set; }
        [Serialize(18), String(16)]
        public string Name { get; set; }
    }
}