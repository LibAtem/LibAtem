using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_mpl", 4), NoCommandId]
    public class MediaPoolConfigCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint StillCount { get; set; }
        [Serialize(1), UInt8]
        public uint ClipCount { get; set; }
    }
}