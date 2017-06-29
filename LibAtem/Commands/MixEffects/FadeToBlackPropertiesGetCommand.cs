using LibAtem.Common;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("FtbC")]
    public class FadeToBlackPropertiesGetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public uint Rate { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddUInt8((uint)Rate);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MixEffectBlockId)cmd.GetUInt8();
            Rate = cmd.GetUInt8(1, 250);
            cmd.Skip(2);
        }
    }
}