using LibAtem.Common;

namespace LibAtem.Commands.Settings
{
    [CommandName("CVdM")]
    public class VideoModeSetCommand : ICommand
    {
        public VideoMode VideoMode { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((uint)VideoMode);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            VideoMode = (VideoMode) cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}