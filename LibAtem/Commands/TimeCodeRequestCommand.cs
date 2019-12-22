using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("TiRq", CommandDirection.ToServer, 0), NoCommandId]
    public class TimeCodeRequestCommand : SerializableCommandBase
    {
    }
}