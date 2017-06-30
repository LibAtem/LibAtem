using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKDV")]
    public class MixEffectKeyDVESetCommand : ICommand
    {
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.Pad(4); // Mask
            cmd.AddUInt8((int)MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.Pad(58);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            cmd.Skip(4);
            MixEffectIndex = (MixEffectBlockId)cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            cmd.Skip(58);
        }
    }
}