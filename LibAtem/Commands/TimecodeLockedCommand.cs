using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("TcLk", CommandDirection.ToClient, ProtocolVersion.V8_0, 4), NoCommandId]
    public class TimecodeLockedCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool Locked { get; set; }
    }
}