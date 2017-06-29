using LibAtem.Common;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsT")]
    public class DownstreamKeyTieSetCommand : ICommand
    {
        public DownstreamKeyId Index { get; set; }
        public bool Tie { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddBoolArray(Tie);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (DownstreamKeyId)cmd.GetUInt8();
            Tie = cmd.GetBoolArray()[0];
            cmd.Skip(2);
        }
    }
}