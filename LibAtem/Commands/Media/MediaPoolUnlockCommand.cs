using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("LOCK", 4)]
    public class MediaPoolUnlockCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MediaPoolFileType Type { get; set; }
        [Serialize(1), UInt8]
        public uint Index { get; set; }
    }
}