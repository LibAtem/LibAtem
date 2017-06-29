using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeLm")]
    public class MixEffectKeyLumaGetCommand : ICommand
    {
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public bool PreMultiplied { get; set; }
        public double Clip { get; set; }
        public double Gain { get; set; }
        public bool Invert { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddBoolArray(PreMultiplied);
            cmd.Pad();
            cmd.AddUInt16(1000, Clip);
            cmd.AddUInt16(1000, Gain);
            cmd.AddBoolArray(Invert);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MixEffectIndex = (MixEffectBlockId)cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            PreMultiplied = cmd.GetBoolArray()[0];
            cmd.Skip();
            Clip = cmd.GetUInt16(0, 1000) / 1000d;
            Gain = cmd.GetUInt16(0, 1000) / 1000d;
            Invert = cmd.GetBoolArray()[0];
            cmd.Skip();
        }
    }
}