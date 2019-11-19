namespace LibAtem.Commands
{
    [CommandName("InCm", CommandDirection.ToClient), NoCommandId]
    public class InitializationCompleteCommand : ICommand
    {
        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddByte(0x01, 0x00); // ??
            cmd.Pad(2);
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            cmd.Skip(4);
        }
    }
}