namespace LibAtem.Commands.Media
{
    [CommandName("CLMP", CommandDirection.ToServer, 0), NoCommandId]
    public class MediaPoolClearAllCommand : SerializableCommandBase
    {
    }
}