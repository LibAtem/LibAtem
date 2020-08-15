using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("TiRq", CommandDirection.ToServer, ProtocolVersion.V8_0, 0), NoCommandId]
    public class TimeCodeRequestCommand : SerializableCommandBase
    {
    }
}