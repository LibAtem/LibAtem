namespace LibAtem.Commands.Recording
{
    [CommandName("RMDR", CommandDirection.ToServer, 0), NoCommandId]
    public class RecordingRequestDurationCommand : SerializableCommandBase
    {
    }
}