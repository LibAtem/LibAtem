using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("MPAS", 84)]
    public class MediaPoolAudioDescriptionCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint Index { get; set; }
        [Serialize(1), Bool]
        public bool IsUsed { get; set; }

        [Serialize(2), ByteArray(16)]
        public byte[] Hash { get; set; }

        [Serialize(18), String(64)]
        public string Name { get; set; }
    }
}