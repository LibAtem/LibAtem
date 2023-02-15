using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [NoCommandId]
    [CommandName("DCPV", CommandDirection.ToClient, 20)]
    public class DisplayClockPropertiesGetCommand : SerializableCommandBase
    {
        /*
        [CommandId]
        [Serialize(0), UInt8]
        public uint Id { get; set; }
        */

        [Serialize(1), Bool]
        public bool Enabled { get; set; }

        [Serialize(5), UInt8Range(0, 100)]
        public uint Opacity { get; set; }


        [Serialize(3), UInt8Range(0, 100)]
        public uint Size { get; set; }

        [Serialize(6), Int16D(1000, -16 * 1000, 16 * 1000)]
        public double PositionX { get; set; }

        [Serialize(8), Int16D(1000, -9 * 1000, 9 * 1000)]
        public double PositionY { get; set; }

        [Serialize(10), Bool]
        public bool AutoHide { get; set; }

        [Serialize(11), HyperDeckTime]
        public HyperDeckTime StartFrom { get; set; }

        [Serialize(15), Enum8]
        public DisplayClockClockMode ClockMode { get; set; }

        [Serialize(16), Enum8]
        public DisplayClockClockState ClockState { get; set; }
    }
}