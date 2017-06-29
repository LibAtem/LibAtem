namespace LibAtem.Commands.Audio
{
    [CommandName("AMTP")] // TODO - what is this command for?
    public class AudioMixerTallyPropertiesCommand : ICommand
    {
        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddByte(0x00, 0x00, 0x00, 0x00);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            cmd.Skip(4);
        }
    }
}