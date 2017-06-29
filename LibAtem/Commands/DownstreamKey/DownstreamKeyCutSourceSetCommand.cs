using LibAtem.Common;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsC")]
    public class DownstreamKeyCutSourceSetCommand : ICommand
    {
        public DownstreamKeyId Index { get; set; }
        public VideoSource Source { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.Pad();
            cmd.AddUInt16((int)Source);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (DownstreamKeyId)cmd.GetUInt8();
            cmd.Skip();
            Source = (VideoSource)cmd.GetUInt16();
        }
    }
}