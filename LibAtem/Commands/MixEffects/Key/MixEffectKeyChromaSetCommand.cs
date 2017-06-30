using System;
using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKCk")]
    public class MixEffectKeyChromaSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Hue = 1 << 0,
            Gain = 1 << 1,
            YSuppress = 1 << 2,
            Lift = 1 << 3,
            Narrow = 1 << 4,
        }

        public MaskFlags Mask { get; set; }
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public double Hue { get; set; }
        public double Gain { get; set; }
        public double YSuppress { get; set; }
        public double Lift { get; set; }
        public bool Narrow { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.AddUInt8((int) MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.Pad();
            cmd.AddUInt16(10, Hue);
            cmd.AddUInt16(10, Gain);
            cmd.AddUInt16(10, YSuppress);
            cmd.AddUInt16(10, Lift);
            cmd.AddBoolArray(Narrow);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            MixEffectIndex = (MixEffectBlockId) cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            cmd.Skip();
            Hue = cmd.GetUInt16(0, 3599) / 10d;
            Gain = cmd.GetUInt16(0, 1000) / 10d;
            YSuppress = cmd.GetUInt16(0, 1000) / 10d;
            Lift = cmd.GetUInt16(0, 1000) / 10d;
            Narrow = cmd.GetBoolArray()[0];
            cmd.Skip(3);
        }
    }
}