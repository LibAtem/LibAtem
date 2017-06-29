using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TStP")]
    public class TransitionStingerGetCommand : ICommand
    {
        public MixEffectBlockId Index { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddByte(0x00);
            cmd.AddByte(0x01);
            cmd.AddByte(0x01);
            cmd.AddByte(0x60);
            cmd.AddByte(0x01);
            cmd.AddByte(0xf4);
            cmd.AddByte(0x02);
            cmd.AddByte(0xbc);
            cmd.AddByte(0x00);
            cmd.AddByte(0x08);
            cmd.AddByte(0x00);
            cmd.AddByte(0x02);
            cmd.AddByte(0x00);
            cmd.AddByte(0x49);
            cmd.AddByte(0x00);
            cmd.AddByte(0x22);
            cmd.AddByte(0x00);
            cmd.AddByte(0x05);
            cmd.AddByte(0x6f);
            cmd.AddByte(0x72);

//            var res = new CommandBuilder("TStP");
//            res.AddUInt8((int)me.Index);
//            res.AddUInt8(1); // TODO
//            res.AddBoolArray(param.PreMultipliedKey.Value());
//            res.Pad(1);
//            res.AddUInt16(10000, param.Clip);
//            res.AddUInt16(10000, param.Gain);
//            res.AddBoolArray(param.Invert.Value());
//            res.Pad(1);
//            res.AddUInt16(10000, param.Preroll);
//            res.AddUInt16(10000, param.ClipDuration);
//            res.AddUInt16(10000, param.TriggerPoint);
//            res.AddUInt16(10000, param.MixRate);
//            res.Pad(2);
            //return res;
        }

        public void Deserialize(ParsedCommand cmd)
        {
            //TODO
            cmd.Skip(20);
        }
    }
}