using LibAtem.Common;

namespace LibAtem.Commands.Media
{
    [CommandName("RCPS")]
    public class MediaPlayerStatusCommand : ICommand
    {
        public MediaPlayerId Index { get; set; }
        public bool Playing { get; set; }
        public bool Loop { get; set; }
        public bool AtBeginning { get; set; }
        public uint ClipFrame { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddBoolArray(Playing);
            cmd.AddBoolArray(Loop);
            cmd.AddBoolArray(AtBeginning);
            cmd.AddUInt16(ClipFrame);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MediaPlayerId)cmd.GetUInt8();
            Playing = cmd.GetBoolArray()[0];
            Loop = cmd.GetBoolArray()[0];
            AtBeginning = cmd.GetBoolArray()[0];
            ClipFrame = cmd.GetUInt16();
        }
    }
}