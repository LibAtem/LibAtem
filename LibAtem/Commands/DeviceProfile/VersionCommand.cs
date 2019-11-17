using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_ver", 4), NoCommandId]
    public class VersionCommand : SerializableCommandBase
    {
        public VersionCommand()
        {
            ProtocolVersion = ProtocolVersion.Latest;
        }

        [Serialize(0), Enum32]
        public ProtocolVersion ProtocolVersion { get; set; }
    }
}