using LibAtem.Common;

namespace LibAtem.Commands
{
    [CommandName("CAuS")]
    public class AuxSourceSetCommand : ICommand
    {
        public AuxSourceSetCommand()
        {
            Id = 0;
            Source = VideoSource.Black;
        }

        public uint Id { get; set; }
        public VideoSource Source { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddBoolArray(true);
            cmd.AddUInt8(Id);
            cmd.AddVideoSource(Source);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            cmd.Skip();

            Id = cmd.GetUInt8();
            Source = cmd.GetVideoSource();
        }
    }
}