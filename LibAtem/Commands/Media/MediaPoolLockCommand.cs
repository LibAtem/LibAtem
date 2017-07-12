using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("PLCK", 8)]
    public class MediaPoolLockCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MediaPoolFileType Type { get; set; } // ??? wireshark is calling this byte storeId
        [Serialize(3), UInt8]
        public uint Index { get; set; }
    }
}