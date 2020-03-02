using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("CMPC", CommandDirection.ToServer, 4)]
    public class MediaPoolClearClipCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint Index { get; set; }
    }
}