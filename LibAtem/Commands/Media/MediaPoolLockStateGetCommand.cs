using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("LKST", 4)]
    public class MediaPoolLockStateGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MediaPoolFileType Type { get; set; }
        [CommandId]
        [Serialize(1), UInt8]
        public uint Index { get; set; }
        [Serialize(2), Bool]
        public bool Locked { get; set; }
    }
}