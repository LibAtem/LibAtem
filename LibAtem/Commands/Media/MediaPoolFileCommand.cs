using LibAtem.Common;

namespace LibAtem.Commands.Media
{
    [CommandName("MPfe")]
    public class MediaPoolFileCommand : ICommand
    {
        public MediaPoolFileType Type { get; set; }
        public uint Index { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Type);
            cmd.AddByte(0x45);
            cmd.Pad();
            cmd.AddUInt8(Index);
            cmd.Pad(17); // ?? (Various bits)
            cmd.AddByte(0x1b, 0x00, 0x00);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Type = (MediaPoolFileType) cmd.GetUInt8();
            cmd.Skip(2);
            Index = cmd.GetUInt8();
            cmd.Skip(20);
        }
    }
}