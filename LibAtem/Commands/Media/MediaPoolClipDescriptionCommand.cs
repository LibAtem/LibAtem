using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("MPCS", 68)]
    public class MediaPoolClipDescriptionCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint Index { get; set; }

        [Serialize(1), Bool]
        public bool IsUsed { get; set; }

        [Serialize(2), String(64)]
        public string Name { get; set; }

        [Serialize(66), UInt16]
        public uint FrameCount { get; set; }
    }
}