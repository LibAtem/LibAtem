using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TStP", 20)]
    public class TransitionStingerGetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), Enum8]
        public StingerSource Source { get; set; }
        [Serialize(2), Bool]
        public bool PreMultipliedKey { get; set; }

        [Serialize(4), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(8), Bool]
        public bool Invert { get; set; }

        [Serialize(10), UInt16]
        public uint Preroll { get; set; }
        [Serialize(12), UInt16]
        public uint ClipDuration { get; set; }
        [Serialize(14), UInt16]
        public uint TriggerPoint { get; set; }
        [Serialize(16), UInt16]
        public uint MixRate { get; set; }

//        public void Serialize(CommandBuilder cmd)
//        {
//            cmd.AddUInt8((int)Index);
//            cmd.AddUInt8(1); // TODO
//            cmd.AddBoolArray(PreMultipliedKey);
//            cmd.Pad(1);
//            cmd.AddUInt16(1000, Clip);
//            cmd.AddUInt16(1000, Gain);
//            cmd.AddBoolArray(Invert);
//            cmd.Pad(1);
//            cmd.AddUInt16(1, Preroll);
//            cmd.AddUInt16(1, ClipDuration);
//            cmd.AddUInt16(1, TriggerPoint);
//            cmd.AddUInt16(1, MixRate);
//            cmd.Pad(2);
//            //            cmd.AddByte(0x00);
//            //            cmd.AddByte(0x01);
//            //            cmd.AddByte(0x01);
//            //            cmd.AddByte(0x60);
//            //            cmd.AddByte(0x01);
//            //            cmd.AddByte(0xf4);
//            //            cmd.AddByte(0x02);
//            //            cmd.AddByte(0xbc);
//            //            cmd.AddByte(0x00);
//            //            cmd.AddByte(0x08);
//            //            cmd.AddByte(0x00);
//            //            cmd.AddByte(0x02);
//            //            cmd.AddByte(0x00);
//            //            cmd.AddByte(0x49);
//            //            cmd.AddByte(0x00);
//            //            cmd.AddByte(0x22);
//            //            cmd.AddByte(0x00);
//            //            cmd.AddByte(0x05);
//            //            cmd.AddByte(0x6f);
//            //            cmd.AddByte(0x72);
//
//        }
//
//        public void Deserialize(ParsedCommand cmd)
//        {
//            //TODO
//            cmd.Skip(20);
//        }
    }
}