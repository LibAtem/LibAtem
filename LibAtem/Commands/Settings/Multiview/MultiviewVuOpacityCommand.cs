namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("VuMo")]
    public class MultiviewVuOpacityCommand : ICommand
    {
        public uint MultiviewIndex { get; set; }
        public double Opacity { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(MultiviewIndex);
            cmd.AddUInt8(100, Opacity);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MultiviewIndex = cmd.GetUInt8();
            Opacity = cmd.GetUInt8(10, 100)/100d;
            cmd.Skip(2);
        }
    }
}