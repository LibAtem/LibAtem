namespace LibAtem.Commands.Media
{
    [CommandName("CMPS"), NoCommandId]
    public class MediaPoolSettingsSetCommand : ICommand
    {
        public uint Clip1MaxFrames { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(Clip1MaxFrames);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Clip1MaxFrames = cmd.GetUInt16();
            cmd.Skip(2);
        }
    }
}