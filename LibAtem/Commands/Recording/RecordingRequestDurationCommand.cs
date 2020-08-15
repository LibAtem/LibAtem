namespace LibAtem.Commands.Recording
{
    [CommandName("RMDR", CommandDirection.ToServer, ProtocolVersion.V8_1_1, 0), NoCommandId]
    public class RecordingRequestDurationCommand : SerializableCommandBase
    {
    }
}