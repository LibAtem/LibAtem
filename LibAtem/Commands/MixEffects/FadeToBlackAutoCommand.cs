using LibAtem.Common;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("FtbA")]
    public class FadeToBlackAutoCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MixEffectBlockId)cmd.GetUInt8();
            cmd.Skip(3);
        }
    }
}