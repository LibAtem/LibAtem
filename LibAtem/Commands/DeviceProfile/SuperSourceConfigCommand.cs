using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_SSC", 4), NoCommandId]
    public class SuperSourceConfigCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint Boxes { get; set; }
    }
}