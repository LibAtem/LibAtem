using LibAtem.Common;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("MvIn")]
    public class MultiviewWindowInputGetCommand : ICommand
    {
        public uint MultiviewIndex { get; set; }
        public uint WindowIndex { get; set; }
        public VideoSource Source { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(MultiviewIndex);
            cmd.AddUInt8(WindowIndex);
            cmd.AddUInt16((uint)Source);
            cmd.AddByte(0x00); // ??
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MultiviewIndex = cmd.GetUInt8();
            WindowIndex = cmd.GetUInt8();
            Source = (VideoSource)cmd.GetUInt16();
            cmd.Skip(4);
        }
    }
}