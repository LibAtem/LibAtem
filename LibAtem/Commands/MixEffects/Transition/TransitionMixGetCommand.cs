using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TMxP")]
    public class TransitionMixGetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public uint Rate { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddUInt8(Rate);
            // TODO - what are these values?
            cmd.AddByte(0x46);
            cmd.AddByte(0x6f);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MixEffectBlockId)cmd.GetUInt8();
            Rate = cmd.GetUInt8();
            cmd.Skip(2);
        }
    }
}