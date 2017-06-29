using LibAtem.Common;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("CDsL")]
    public class DownstreamKeyOnAirSetCommand : ICommand
    {
        public DownstreamKeyId Index { get; set; }
        public bool OnAir { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddBoolArray(OnAir);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (DownstreamKeyId)cmd.GetUInt8();
            OnAir = cmd.GetBoolArray()[0];
            cmd.Skip(2);
        }
    }
}