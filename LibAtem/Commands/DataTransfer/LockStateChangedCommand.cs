using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("LKST", CommandDirection.ToClient, 4)]
    public class LockStateChangedCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint Index { get; set; }

        [Serialize(2), Bool]
        public bool Locked { get; set; }
    }
}