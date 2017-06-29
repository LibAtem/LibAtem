using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TDpP")]
    public class TransitionDipGetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public uint Rate { get; set; }
        public VideoSource Input { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Index);
            cmd.AddUInt8(Rate);
            cmd.AddUInt16((int) Input);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MixEffectBlockId) cmd.GetUInt8();
            Rate = cmd.GetUInt8();
            Input = (VideoSource) cmd.GetUInt16();
        }
    }
}