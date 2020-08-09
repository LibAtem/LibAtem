using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("TCCc", CommandDirection.ToClient, ProtocolVersion.V8_1_1, 4), NoCommandId]
    public class TimeCodeConfigGetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public TimeCodeMode Mode { get; set; }
    }
}