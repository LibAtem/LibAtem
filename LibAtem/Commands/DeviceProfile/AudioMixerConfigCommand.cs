namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_AMC")]
    public class AudioMixerConfigCommand : ICommand
    {
        public uint Inputs { get; set; }
        public bool HasMonitor { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(Inputs);
            cmd.AddBoolArray(HasMonitor); // TODO - verify this is the correct name
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Inputs = cmd.GetUInt8();
            HasMonitor = cmd.GetBoolArray()[0];
            cmd.Skip(2);
        }
    }
}