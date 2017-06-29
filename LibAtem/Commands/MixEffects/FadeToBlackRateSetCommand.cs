using LibAtem.Common;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("FtbC")]
    public class FadeToBlackRateSetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public uint Rate { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddBoolArray(true); // Mask Flag
            cmd.AddUInt8((int)Index);
            cmd.AddUInt8((uint) Rate);
            cmd.Pad();
        }

        public void Deserialize(ParsedCommand cmd)
        {
            cmd.Skip(); // Mask Flag
            Index = (MixEffectBlockId)cmd.GetUInt8();
            Rate = cmd.GetUInt8(1, 250);
            cmd.Skip();
        }
    }
}