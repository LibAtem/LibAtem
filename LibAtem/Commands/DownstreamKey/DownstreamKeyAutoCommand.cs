using LibAtem.Common;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DDsA")]
    public class DownstreamKeyAutoCommand : ICommand
    {
        public DownstreamKeyId Index { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (DownstreamKeyId)cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}