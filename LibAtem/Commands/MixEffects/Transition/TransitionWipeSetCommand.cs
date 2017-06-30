using System;
using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTWp")]
    public class TransitionWipeSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Rate = 1 << 0,
            Pattern = 1 << 1,
            BorderWidth = 1 << 2,
            BorderInput = 1 << 3,
            Symmetry = 1 << 4,
            BorderSoftness = 1 << 5,
            XPosition = 1 << 6,
            YPosition = 1 << 7,
            ReverseDirection = 1 << 8,
            FlipFlop = 1 << 9,

        }

        public MaskFlags Mask { get; set; }
        public MixEffectBlockId Index { get; set; }
        public uint Rate { get; set; }
        public Pattern Pattern { get; set; }
        public double BorderWidth { get; set; }
        public VideoSource BorderInput { get; set; }
        public double Symmetry { get; set; }
        public double BorderSoftness { get; set; }
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public bool ReverseDirection { get; set; }
        public bool FlipFlop { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.AddUInt8((int) Index);
            cmd.AddUInt8(Rate);
            cmd.AddUInt8((int) Pattern);
            cmd.AddUInt16(100, BorderWidth);
            cmd.AddUInt16((int) BorderInput);
            cmd.AddUInt16(100, Symmetry);
            cmd.AddUInt16(100, BorderSoftness);
            cmd.AddUInt16(10000, XPosition);
            cmd.AddUInt16(10000, YPosition);
            cmd.AddBoolArray(ReverseDirection);
            cmd.AddBoolArray(FlipFlop);
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            Index = (MixEffectBlockId) cmd.GetUInt8();
            Rate = cmd.GetUInt8(1, 250);
            Pattern = (Pattern) cmd.GetUInt8();
            BorderWidth = cmd.GetUInt16(0, 10000) / 100d;
            BorderInput = (VideoSource)cmd.GetUInt16();
            Symmetry = cmd.GetUInt16(0, 10000) / 100d;
            BorderSoftness = cmd.GetUInt16(0, 10000) / 100d;
            XPosition = cmd.GetUInt16(0, 10000) / 10000d;
            YPosition = cmd.GetUInt16(0, 10000) / 10000d;
            ReverseDirection = cmd.GetBoolArray()[0];
            FlipFlop = cmd.GetBoolArray()[0];
            cmd.Skip(2);
        }
    }
}