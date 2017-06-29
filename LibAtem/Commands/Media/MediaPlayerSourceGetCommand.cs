using LibAtem.Common;

namespace LibAtem.Commands.Media
{
    [CommandName("MPCE")]
    public class MediaPlayerSourceGetCommand : ICommand
    {
        public MediaPlayerId Index { get; set; }
        public MediaPlayerSource SourceType { get; set; }
        public uint SourceIndex { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddUInt8((int)SourceType);
            if (SourceType == MediaPlayerSource.Still) // TODO - verify this is correct
            {
                cmd.AddUInt8(SourceIndex);
                cmd.AddUInt8(0);
            }
            else
            {
                cmd.AddUInt8(0);
                cmd.AddUInt8(SourceIndex);
            }
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MediaPlayerId) cmd.GetUInt8();
            SourceType = (MediaPlayerSource) cmd.GetUInt8();
            if (SourceType == MediaPlayerSource.Still) // TODO - verify this is correct
            {
                SourceIndex = cmd.GetUInt8();
                cmd.Skip();
            }
            else
            {
                cmd.Skip();
                SourceIndex = cmd.GetUInt8();
            }
        }
    }
}