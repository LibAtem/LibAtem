using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("PLCK", 8)]
    public class MediaPoolLockCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MediaPoolFileType Type { get; set; } // ??? wireshark is calling this byte storeId
        [CommandId]
        [Serialize(3), UInt8]
        public uint Index { get; set; }
    }
}