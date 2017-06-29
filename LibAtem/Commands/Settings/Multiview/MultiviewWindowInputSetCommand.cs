using LibAtem.Common;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("CMvI")]
    public class MultiviewWindowInputSetCommand : ICommand
    {
        public uint MultiviewIndex { get; set; }
        public uint WindowIndex { get; set; }
        public VideoSource Source { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(MultiviewIndex);
            cmd.AddUInt8(WindowIndex);
            cmd.AddUInt16((uint) Source);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MultiviewIndex = cmd.GetUInt8();
            WindowIndex = cmd.GetUInt8();
            Source = (VideoSource) cmd.GetUInt16();
        }
    }
}