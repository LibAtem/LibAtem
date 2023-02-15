using LibAtem.Common;
using LibAtem.Serialization;
using System;

namespace LibAtem.Commands
{
    [NoCommandId]
    [CommandName("DCPC", CommandDirection.ToServer, 28)]
    public class DisplayClockPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Enabled = 1 << 0,
            Size = 1 << 1,
            Opacity = 1 << 2,
            PositionX = 1 << 3,
            PositionY = 1 << 4,
            AutoHide = 1 << 5,
            StartFrom = 1 << 6,
            StartFromFrames = 1 << 7,
            ClockMode = 1 << 8,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }

        /*
        [CommandId]
        [Serialize(0), UInt8]
        public uint Id { get; set; }
        */

        [Serialize(3), Bool]
        public bool Enabled { get; set; }

        [Serialize(7), UInt8Range(0, 100)]
        public uint Opacity { get; set; }


        [Serialize(5), UInt8Range(0, 100)]
        public uint Size { get; set; }

        [Serialize(8), Int16D(1000, -16 * 1000, 16 * 1000)]
        public double PositionX { get; set; }

        [Serialize(10), Int16D(1000, -9 * 1000, 9 * 1000)]
        public double PositionY { get; set; }

        [Serialize(12), Bool]
        public bool AutoHide { get; set; }

        [Serialize(13), HyperDeckTime]
        public HyperDeckTime StartFrom { get; set; }

        [Serialize(20), UInt32]
        public uint StartFromFrames { get; set; }

        [Serialize(24), Enum8]
        public DisplayClockClockMode ClockMode { get; set; }
    }
}