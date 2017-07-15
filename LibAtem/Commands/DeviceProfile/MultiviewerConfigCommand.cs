namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_MvC"), NoCommandId]
    public class MultiviewerConfigCommand : ICommand
    {
        public uint Count { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(Count);
            cmd.AddByte(0x0a);
            cmd.AddByte(0x01);
            cmd.AddByte(0x01);
            cmd.AddByte(0x00);
            cmd.AddByte(0x01);
            cmd.AddByte(0x01);
            cmd.AddByte(0x01);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Count = cmd.GetUInt8();
            cmd.Skip(7);
        }
    }
}