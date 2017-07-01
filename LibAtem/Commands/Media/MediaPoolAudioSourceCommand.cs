using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("MPAS", 84)]
    public class MediaPoolAudioSourceCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8]
        public uint Index { get; set; }
        [Serializable(1), Bool]
        public bool IsUsed { get; set; }
        [Serializable(18), String(16)]
        public string Name { get; set; }
    }
}