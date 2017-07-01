using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_ver", 4)]
    public class VersionCommand : SerializableCommandBase
    {
        public VersionCommand()
        {
            ApiMajor = Version.ApiMajor;
            ApiMinor = Version.ApiMinor;
        }

        [Serialize(0), UInt16]
        public uint ApiMajor { get; protected set; }
        [Serialize(2), UInt16]
        public uint ApiMinor { get; protected set; }
    }
}