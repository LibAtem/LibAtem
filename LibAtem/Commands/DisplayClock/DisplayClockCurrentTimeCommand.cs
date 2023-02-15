using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [NoCommandId]
    [CommandName("DSTV", CommandDirection.ToClient, 8)]
    public class DisplayClockCurrentTimeCommand : SerializableCommandBase
    {
        /*
        [CommandId]
        [Serialize(0), UInt8]
        public uint Id { get; set; }
        */

        [Serialize(1), HyperDeckTime]
        public HyperDeckTime Time { get; set; }
    }
}