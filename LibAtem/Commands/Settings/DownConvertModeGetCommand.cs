using LibAtem.Common;

namespace LibAtem.Commands.Settings
{
    [CommandName("DcOt")]
    public class DownConvertModeGetCommand : ICommand
    {
        public DownConvertMode DownConvertMode { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)DownConvertMode);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            DownConvertMode = (DownConvertMode) cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}