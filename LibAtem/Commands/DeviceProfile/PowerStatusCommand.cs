namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("Powr")]
    public class PowerStatusCommand : ICommand
    {
        public bool Pin1 { get; set; }
        public bool Pin2 { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddBoolArray(Pin1, Pin2);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            bool[] arr = cmd.GetBoolArray();
            Pin1 = arr[0];
            Pin2 = arr[1];

            cmd.Skip(3);
        }
    }
}