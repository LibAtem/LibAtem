using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.CameraControl
{
    [CommandName("CCdo", CommandDirection.ToServer, 8)]
    public class CameraControlDeviceOptionsSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            PeriodicFlushEnabled = 1 << 0,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(1), Enum8]
        public VideoSource Input { get; set; }

        [CommandId]
        [Serialize(2), UInt8]
        public uint Category { get; set; }
        [CommandId]
        [Serialize(3), UInt8]
        public uint Parameter { get; set; }

        [Serialize(4), Bool]
        public bool PeriodicFlushEnabled { get; set; }
    }
}