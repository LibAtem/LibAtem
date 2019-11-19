using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("LOCK", CommandDirection.ToServer, 4)]
    public class LockStateSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint Index { get; set; }

        [Serialize(2), Bool]
        public bool Locked { get; set; }
    }
}