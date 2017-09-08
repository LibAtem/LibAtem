namespace LibAtem.Commands.Audio
{
    [CommandName("AMTP"), NoCommandId] // TODO - what is this command for?
    public class AudioMixerTallyPropertiesCommand : ICommand
    {
        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddByte(0x00, 0x00, 0x00, 0x00);
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            cmd.Skip(4);
        }
    }
}