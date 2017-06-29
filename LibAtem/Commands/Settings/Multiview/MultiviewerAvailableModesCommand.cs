using LibAtem.Common;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("MvVM")]
    public class MultiviewerAvailableModesCommand : ICommand
    {
        public VideoMode CoreVideoMode { get; set; }
        public VideoMode MultiviewMode { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)CoreVideoMode);
            cmd.AddUInt8((int)MultiviewMode);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            CoreVideoMode = (VideoMode)cmd.GetUInt8();
            MultiviewMode = (VideoMode)cmd.GetUInt8();
            cmd.Skip(2);
        }
    }
}