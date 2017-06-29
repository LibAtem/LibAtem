using LibAtem.Common;

namespace LibAtem.Commands.DownstreamKey
{
    [CommandName("DskS")]
    public class DownstreamKeyStateGetCommand : ICommand
    {
        public DownstreamKeyId Index { get; set; }
        public bool OnAir { get; set; }
        public bool InTransition { get; set; }
        public bool IsAuto { get; set; }
        public uint RemainingFrames { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddBoolArray(OnAir);
            cmd.AddBoolArray(InTransition); // In transition
            cmd.AddBoolArray(IsAuto); // Is auto
            cmd.AddUInt8(RemainingFrames); // Frames remaining
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (DownstreamKeyId) cmd.GetUInt8();
            OnAir = cmd.GetBoolArray()[0];
            InTransition = cmd.GetBoolArray()[0];
            IsAuto = cmd.GetBoolArray()[0];
            RemainingFrames = cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}