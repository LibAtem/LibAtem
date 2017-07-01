using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("MPCS", 68)]
    public class MediaPoolClipSourceCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8]
        public uint Index { get; set; }
        [Serializable(1), Bool]
        public bool IsUsed { get; set; }
        [Serializable(2), String(16)] // TODO - should there be 48 more bytes of name?
        public string Name { get; set; }
        [Serializable(66), UInt16]
        public uint FrameCount { get; set; }
    }
}