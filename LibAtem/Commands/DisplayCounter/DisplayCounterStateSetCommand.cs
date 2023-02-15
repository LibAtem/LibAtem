using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("DCSC", CommandDirection.ToServer, 4)]
    public class DisplayCounterStateSetCommand : SerializableCommandBase
    {
        /*
        [CommandId]
        [Serialize(0), UInt8]
        public uint Id { get; set; }
        */

        [Serialize(1), Enum8]
        public DisplayCounterClockState State { get; set; }
    }
}