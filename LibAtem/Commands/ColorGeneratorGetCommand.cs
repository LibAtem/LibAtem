namespace LibAtem.Commands
{
    [CommandName("ColV")]
    public class ColorGeneratorGetCommand : ICommand
    {
        public uint Index { get; set; }
        public double Hue { get; set; }
        public double Saturation { get; set; }
        public double Luma { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(Index);
            cmd.Pad();
            cmd.AddUInt16(10, Hue);
            cmd.AddUInt16(10, Saturation);
            cmd.AddUInt16(10, Luma);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = cmd.GetUInt8();
            cmd.Skip();
            Hue = cmd.GetUInt16() / 10d;
            Saturation = cmd.GetUInt16() / 10d;
            Luma = cmd.GetUInt16() / 10d;
        }
    }
}