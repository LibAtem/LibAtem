using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_SSC", 4)]
    public class SuperSourceConfigCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8]
        public uint Boxes { get; set; }
    }
}