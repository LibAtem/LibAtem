using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [NoCommandId]
    [CommandName("DCSC", CommandDirection.ToServer, 4)]
    public class DisplayClockStateSetCommand : SerializableCommandBase
    {
        /*
        [CommandId]
        [Serialize(0), UInt8]
        public uint Id { get; set; }
        */

        [Serialize(1), Enum8]
        public DisplayClockClockState State { get; set; }
    }
}