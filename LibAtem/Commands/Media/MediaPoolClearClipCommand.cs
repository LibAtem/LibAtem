using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("CMPC", 4)]
    public class MediaPoolClearClipCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint Index { get; set; }
    }
}