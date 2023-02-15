namespace LibAtem.Commands
{
    [NoCommandId]
    [CommandName("DSTR", CommandDirection.ToServer, 4)]
    public class DisplayClockRequestTimeCommand : SerializableCommandBase
    {
        /*
        [CommandId]
        [Serialize(0), UInt8]
        public uint Id { get; set; }
        */
    }
}