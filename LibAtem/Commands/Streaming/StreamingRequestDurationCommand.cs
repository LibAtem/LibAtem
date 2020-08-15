namespace LibAtem.Commands.Streaming
{
    [CommandName("SRDR", CommandDirection.ToServer, ProtocolVersion.V8_1_1, 0), NoCommandId]
    public class StreamingRequestDurationCommand : SerializableCommandBase
    {
    }
}