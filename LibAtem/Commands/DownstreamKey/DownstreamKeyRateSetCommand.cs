using LibAtem.Common;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsR")]
    public class DownstreamKeyRateSetCommand : ICommand
    {
        public DownstreamKeyId Index { get; set; }
        public uint Rate { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddUInt8(Rate);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (DownstreamKeyId)cmd.GetUInt8();
            Rate = cmd.GetUInt8(0, 250);
            cmd.Skip(2);
        }
    }
}