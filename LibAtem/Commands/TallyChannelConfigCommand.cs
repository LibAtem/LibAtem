namespace LibAtem.Commands
{
    [CommandName("_TlC")]
    public class TallyChannelConfigCommand : ICommand
    {
        public uint InputCount { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddByte(0x00, 0x01, 0x00, 0x00); // TODO
            cmd.AddUInt8(InputCount);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            cmd.Skip(4);
            InputCount = cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}