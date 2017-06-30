using System;
using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKPt")]
    public class MixEffectKeyPatternSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Pattern = 1 << 0,
            Size = 1 << 1,
            Symmetry = 1 << 2,
            Softness = 1 << 3,
            XPosition = 1 << 4,
            YPosition = 1 << 5,
            Inverse = 1 << 6,
        }

        public MaskFlags Mask { get; set; }
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public Pattern Pattern { get; set; }
        public double Size { get; set; }
        public double Symmetry { get; set; }
        public double Softness { get; set; }
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public bool Inverse { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.AddUInt8((int) MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddUInt8((int) Pattern);
            cmd.AddUInt16(100, Size);
            cmd.AddUInt16(100, Symmetry);
            cmd.AddUInt16(100, Softness);
            cmd.AddUInt16(10000, XPosition);
            cmd.AddUInt16(10000, YPosition);
            cmd.AddBoolArray(Inverse);
            cmd.Pad();
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            MixEffectIndex = (MixEffectBlockId) cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            Pattern = (Pattern) cmd.GetUInt8();
            Size = cmd.GetUInt16(0, 10000) / 100d;
            Symmetry = cmd.GetUInt16(0, 10000) / 100d;
            Softness = cmd.GetUInt16(0, 10000) / 100d;
            XPosition = cmd.GetUInt16(0, 10000) / 10000d;
            YPosition = cmd.GetUInt16(0, 10000) / 10000d;
            Inverse = cmd.GetBoolArray()[0];
            cmd.Skip();
        }
    }
}