using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_SSC", ProtocolVersion.V8_0, 4), NoCommandId]
    public class SuperSourceConfigV8Command : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public SuperSourceId SSrcId { get; set; }
        [Serialize(2), UInt8]
        public uint Boxes { get; set; }
    }
}