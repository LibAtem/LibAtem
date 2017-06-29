using LibAtem.Common;

namespace LibAtem.Commands.Settings
{
    [CommandName("DHVm")]
    public class DownConvertAvailableModesCommand : ICommand
    {
        public VideoMode CoreVideoMode { get; set; }
        public VideoMode DownConvertedMode { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)CoreVideoMode);
            cmd.AddUInt8((int)DownConvertedMode);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            CoreVideoMode = (VideoMode)cmd.GetUInt8();
            DownConvertedMode = (VideoMode)cmd.GetUInt8();
            cmd.Skip(2);
        }
    }
}