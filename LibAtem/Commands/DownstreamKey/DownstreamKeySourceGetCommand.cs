using LibAtem.Common;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DskB")]
    public class DownstreamKeySourceGetCommand : ICommand
    {
        public DownstreamKeyId Index { get; set; }
        public VideoSource FillSource { get; set; }
        public VideoSource CutSource { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.Pad();
            cmd.AddUInt16((uint)FillSource);
            cmd.AddUInt16((uint)CutSource);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (DownstreamKeyId)cmd.GetUInt8();
            cmd.Skip();
            FillSource = (VideoSource)cmd.GetUInt16();
            CutSource = (VideoSource)cmd.GetUInt16();
            cmd.Skip(2);
        }
    }
}