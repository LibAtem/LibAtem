using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("SRsv", CommandDirection.ToServer, 4), NoCommandId]
    public class StartupStateSaveCommand : SerializableCommandBase
    {
        // 0 is the 'mode' parameter, which is always 0 for now
    }
}