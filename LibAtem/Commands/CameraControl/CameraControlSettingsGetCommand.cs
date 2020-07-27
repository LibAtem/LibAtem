using LibAtem.Serialization;

namespace LibAtem.Commands.CameraControl
{
    [CommandName("CCst", CommandDirection.ToClient, 4), NoCommandId]
    public class CameraControlSettingsGetCommand : SerializableCommandBase
    {
        [Serialize(0), UInt32]
        public uint Interval { get; set; }
    }
}