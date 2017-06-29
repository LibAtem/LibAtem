using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKeF")]
    public class MixEffectKeyFillSourceSetCommand : ICommand
    {
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public VideoSource FillSource { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddUInt16((int) FillSource);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MixEffectIndex = (MixEffectBlockId) cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            FillSource = (VideoSource) cmd.GetUInt16();
        }
    }
}