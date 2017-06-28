using LibAtem.Common;

namespace LibAtem.Commands.Settings
{
    [CommandName("VidM")]
    public class VideoModeGetCommand : ICommand
    {
        public VideoMode VideoMode { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) VideoMode);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            VideoMode = (VideoMode) cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}