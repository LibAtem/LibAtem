using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TDvP", CommandDirection.ToClient, 20)]
    public class TransitionDVEGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), UInt8Range(1, 250)]
        public uint Rate { get; set; }
        [Serialize(2), UInt8Range(1, 250)]
        public uint LogoRate { get; set; }
        [Serialize(3), Enum8]
        public DVEEffect Style { get; set; }

        [Serialize(4), Enum16]
        public VideoSource FillSource { get; set; }
        [Serialize(6), Enum16]
        public VideoSource KeySource { get; set; }

        [Serialize(8), Bool]
        public bool EnableKey { get; set; }
        [Serialize(9), Bool]
        public bool PreMultiplied { get; set; }
        [Serialize(10), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serialize(12), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(14), Bool]
        public bool InvertKey { get; set; }
        [Serialize(15), Bool]
        public bool Reverse { get; set; }
        [Serialize(16), Bool]
        public bool FlipFlop { get; set; }

        //        public void Serialize(ByteArrayBuilder cmd)
        //        {
        //            cmd.AddByte(0x0c);
        //            cmd.AddByte(0x00);
        //            cmd.AddByte(0x00);
        //            cmd.AddByte(0x00);
        //            cmd.AddByte(0x0f);
        //            cmd.AddByte(0x54);
        //            cmd.AddByte(0x60);
        //            cmd.AddByte(0x11);
        //            cmd.AddByte(0x54);
        //            cmd.AddByte(0x3a);
        //            cmd.AddByte(0x60);
        //            cmd.AddByte(0x9b);
        //            cmd.AddByte(0x00);
        //            cmd.AddByte(0x01);
        //            cmd.AddByte(0x44);
        //            cmd.AddByte(0x65);
        //            cmd.AddByte(0x61);
        //            cmd.AddByte(0x64);
        //            cmd.AddByte(0x00);
        //            cmd.AddByte(0x60);
        //        }

    }
}