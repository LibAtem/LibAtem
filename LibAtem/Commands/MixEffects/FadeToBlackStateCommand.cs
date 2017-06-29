using LibAtem.Common;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("FtbS")]
    public class FadeToBlackStateCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public bool IsFullyBlack { get; set; }
        public bool InTransition { get; set; }
        public uint RemainingFrames { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Index);
            cmd.AddBoolArray(IsFullyBlack);
            cmd.AddBoolArray(InTransition);
            cmd.AddUInt8(RemainingFrames);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MixEffectBlockId) cmd.GetUInt8();
            IsFullyBlack = cmd.GetBoolArray()[0];
            InTransition = cmd.GetBoolArray()[0];
            RemainingFrames = cmd.GetUInt8();
        }
    }
}