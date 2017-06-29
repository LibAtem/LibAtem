using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeCk")]
    public class MixEffectKeyChromaGetCommand : ICommand
    {
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public double Hue { get; set; }
        public double Gain { get; set; }
        public double YSuppress { get; set; }
        public double Lift { get; set; }
        public bool Narrow { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddUInt16(10, Hue);
            cmd.AddUInt16(10, Gain);
            cmd.AddUInt16(10, YSuppress);
            cmd.AddUInt16(10, Lift);
            cmd.AddBoolArray(Narrow);
            cmd.Pad();
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MixEffectIndex = (MixEffectBlockId)cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            Hue = cmd.GetUInt16(0, 3599) / 10d;
            Gain = cmd.GetUInt16(0, 1000) / 10d;
            YSuppress = cmd.GetUInt16(0, 1000) / 10d;
            Lift = cmd.GetUInt16(0, 1000) / 10d;
            Narrow = cmd.GetBoolArray()[0];
            cmd.Skip();
        }
    }
}