using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KKFP")]
    public class MixEffectKeyFlyKeyframeGetCommand : ICommand
    {
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public uint KeyFrame { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddUInt8(KeyFrame);

            cmd.AddByte(0x20, 0x79, 0x61, 0x6c, 0x50, 0x32, 0x20, 0x72, 0x65, 0x00, 0x00, 0x00, 0x00, 0x50, 0x4d, 0x3a,
                0xc6, 0x00, 0x01, 0x00, 0x32, 0x00, 0x01, 0x00, 0x01, 0x04, 0xf9, 0x13, 0x01, 0x00, 0x2c, 0x60, 0x00,
                0x6e, 0x49, 0x72, 0x50, 0xcd, 0x0b, 0x4d, 0x65, 0x69, 0x64, 0x20, 0x61, 0x6c, 0x50, 0x79, 0x61);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MixEffectIndex = (MixEffectBlockId)cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            KeyFrame = cmd.GetUInt8();
            cmd.Skip(49);
        }
    }
}