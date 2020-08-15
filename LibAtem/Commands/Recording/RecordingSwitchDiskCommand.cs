namespace LibAtem.Commands.Recording
{
    [CommandName("RMSp", CommandDirection.ToServer, ProtocolVersion.V8_1_1, 0), NoCommandId]
    public class RecordingSwitchDiskCommand : SerializableCommandBase
    {
    }
}