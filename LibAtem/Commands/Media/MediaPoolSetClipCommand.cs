using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("SMPC", 68)]
    public class MediaPoolSetClipCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint B0 { get; set; } = 3;

        [CommandId]
        [Serialize(1), UInt8]
        public uint Index { get; set; }

        [Serialize(2), String(44)]
        public string Name { get; set; }

        [Serialize(66), UInt16]
        public uint Frames { get; set; }
    }
}