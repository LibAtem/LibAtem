using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTMx")]
    public class TransitionMixSetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public uint Rate { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddUInt8(Rate);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MixEffectBlockId)cmd.GetUInt8();
            Rate = cmd.GetUInt8();
            cmd.Skip(2);
        }
    }
}