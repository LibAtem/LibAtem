using LibAtem.Common;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("PrvI")]
    public class PreviewInputGetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public VideoSource Source { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)Index);
            cmd.AddByte(0x02);
            cmd.AddUInt16((int)Source);
            cmd.AddByte(0x00);
            cmd.AddByte(0x0a);
            cmd.AddByte(0x13);
            cmd.AddByte(0x01);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Index = (MixEffectBlockId)cmd.GetUInt8();
            cmd.Skip();
            Source = (VideoSource)cmd.GetUInt16();
            cmd.Skip(4);
        }
    }
}