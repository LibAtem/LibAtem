using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("SRcl", CommandDirection.ToServer, 4), NoCommandId]
    public class StartupStateClearCommand : SerializableCommandBase
    {
        // 0 is the 'mode' parameter, which is always 0 for now
    }
}