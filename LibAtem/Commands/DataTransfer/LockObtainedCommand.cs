using LibAtem.Serialization;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("LKOB", CommandDirection.ToClient, 4)]
    public class LockObtainedCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt16]
        public uint Index { get; set; }
    }
}