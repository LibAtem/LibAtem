using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("TiRq", CommandDirection.ToServer), NoCommandId]
    public class TimeCodeRequestCommand : SerializableCommandBase
    {
    }
}