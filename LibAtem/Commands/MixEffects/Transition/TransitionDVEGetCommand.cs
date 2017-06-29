using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TDvP")]
    public class TransitionDVEGetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddByte(0x0c);
            cmd.AddByte(0x00);
            cmd.AddByte(0x00);
            cmd.AddByte(0x00);
            cmd.AddByte(0x0f);
            cmd.AddByte(0x54);
            cmd.AddByte(0x60);
            cmd.AddByte(0x11);
            cmd.AddByte(0x54);
            cmd.AddByte(0x3a);
            cmd.AddByte(0x60);
            cmd.AddByte(0x9b);
            cmd.AddByte(0x00);
            cmd.AddByte(0x01);
            cmd.AddByte(0x44);
            cmd.AddByte(0x65);
            cmd.AddByte(0x61);
            cmd.AddByte(0x64);
            cmd.AddByte(0x00);
            cmd.AddByte(0x60);


            //var res = new TransmitResponse("TDvP");
            //res.AddUInt8((int)me.Index);
            //res.AddUInt8(param.Rate);
            //res.Pad(1);
            //res.AddUInt8((int)param.Effect);
            //res.AddUInt16((int)param.FillSource);
            //res.AddUInt16((int)param.KeySource);
            //res.AddBoolArray(param.EnableKey.Value());
            //res.AddBoolArray(param.PreMultipliedKey.Value());
            //res.AddUInt16(10000, param.Clip);
            //res.AddUInt16(10000, param.Gain);
            //res.AddBoolArray(param.InvertKey.Value());
            //res.AddBoolArray(param.ReverseDirection.Value());
            //res.AddBoolArray(param.FlipFlop.Value());
            //res.Pad(3);
            //return res;
        }

        public void Deserialize(ParsedCommand cmd)
        {
            //TODO
            cmd.Skip(20);
        }
    }
}