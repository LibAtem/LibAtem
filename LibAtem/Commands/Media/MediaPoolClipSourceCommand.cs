using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("MPCS", 68)]
    public class MediaPoolClipSourceCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint Index { get; set; }
        [Serialize(1), Bool]
        public bool IsUsed { get; set; }
        [Serialize(2), String(16)] // TODO - should there be 48 more bytes of name?
        public string Name { get; set; }
        [Serialize(66), UInt16]
        public uint FrameCount { get; set; }
    }
}