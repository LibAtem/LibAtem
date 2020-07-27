using LibAtem.Serialization;

namespace LibAtem.Commands.CameraControl
{
    [CommandName("CCcs", CommandDirection.ToServer, 8), NoCommandId]
    public class CameraControlSettingsSetCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint Mask { get; } = 1;

        [Serialize(4), UInt32]
        public uint Interval { get; set; }
    }
}