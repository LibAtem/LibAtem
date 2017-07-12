using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("CMPS")]
    public class MediaPoolSettingsSetCommand : ICommand
    {
        public uint Clip1MaxFrames { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt16(Clip1MaxFrames);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Clip1MaxFrames = cmd.GetUInt16();
            cmd.Skip(2);
        }
    }
}