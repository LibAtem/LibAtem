using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTPr")]
    public class TransitionPreviewSetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public bool PreviewTransition { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddBoolArray(PreviewTransition);
            cmd.AddByte(0x0a, 0x0a);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MixEffectBlockId)cmd.GetUInt8();
            PreviewTransition = cmd.GetBoolArray()[0];
            cmd.Skip(2);
        }
    }
}