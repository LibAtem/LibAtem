using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKeC")]
    public class MixEffectKeyCutSourceSetCommand : ICommand
    {
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public VideoSource CutSource { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddUInt16((int)CutSource);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MixEffectIndex = (MixEffectBlockId)cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            CutSource = (VideoSource)cmd.GetUInt16();
        }
    }
}