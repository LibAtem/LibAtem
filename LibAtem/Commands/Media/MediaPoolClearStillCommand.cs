using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("CSTL", 4)]
    public class MediaPoolClearStillCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint Index { get; set; }
    }
}