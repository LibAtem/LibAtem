using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_mpl", 4)]
    public class MediaPoolConfigCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8]
        public uint StillCount { get; set; }
        [Serializable(1), UInt8]
        public uint ClipCount { get; set; }
    }
}