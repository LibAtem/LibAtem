using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_SSC", CommandDirection.ToClient, 4), NoCommandId]
    public class SuperSourceConfigCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint Boxes { get; set; }
    }
}