namespace LibAtem.Commands.Media
{
    [CommandName("LKST")]
    public class MediaPoolLockStateGetCommand : ICommand
    {
        public uint Index { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddByte(0x00);
            cmd.AddUInt8(Index);
            cmd.AddByte(0x00);
            cmd.Pad();
        }

        public void Deserialize(ParsedCommand cmd)
        {
            cmd.Skip();
            Index = cmd.GetUInt8();
            cmd.Skip(2);
        }
    }
}