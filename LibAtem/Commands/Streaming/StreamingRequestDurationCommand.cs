namespace LibAtem.Commands.Streaming
{
    [CommandName("SRDR", CommandDirection.ToServer, 0), NoCommandId]
    public class StreamingRequestDurationCommand : SerializableCommandBase
    {
    }
}