using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TStP")]
    public class TransitionStingerGetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }
        public bool PreMultipliedKey { get; set; }
        public double Clip { get; set; }
        public double Gain { get; set; }
        public bool Invert { get; set; }
        public double Preroll { get; set; }
        public double ClipDuration { get; set; }
        public double TriggerPoint { get; set; }
        public double MixRate { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
//            cmd.AddByte(0x00);
//            cmd.AddByte(0x01);
//            cmd.AddByte(0x01);
//            cmd.AddByte(0x60);
//            cmd.AddByte(0x01);
//            cmd.AddByte(0xf4);
//            cmd.AddByte(0x02);
//            cmd.AddByte(0xbc);
//            cmd.AddByte(0x00);
//            cmd.AddByte(0x08);
//            cmd.AddByte(0x00);
//            cmd.AddByte(0x02);
//            cmd.AddByte(0x00);
//            cmd.AddByte(0x49);
//            cmd.AddByte(0x00);
//            cmd.AddByte(0x22);
//            cmd.AddByte(0x00);
//            cmd.AddByte(0x05);
//            cmd.AddByte(0x6f);
//            cmd.AddByte(0x72);

            cmd.AddUInt8((int)Index);
            cmd.AddUInt8(1); // TODO
            cmd.AddBoolArray(PreMultipliedKey);
            cmd.Pad(1);
            cmd.AddUInt16(10000, Clip);
            cmd.AddUInt16(10000, Gain);
            cmd.AddBoolArray(Invert);
            cmd.Pad(1);
            cmd.AddUInt16(10000, Preroll);
            cmd.AddUInt16(10000, ClipDuration);
            cmd.AddUInt16(10000, TriggerPoint);
            cmd.AddUInt16(10000, MixRate);
            cmd.Pad(2);
            //return res;
        }

        public void Deserialize(ParsedCommand cmd)
        {
            //TODO
            cmd.Skip(20);
        }
    }
}