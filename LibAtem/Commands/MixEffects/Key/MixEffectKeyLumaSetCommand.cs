using System;
using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKLm")]
    public class MixEffectKeyLumaSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            PreMultiplied = 1 << 0,
            Clip = 1 << 1,
            Gain = 1 << 2,
            Invert = 1 << 3,
        }

        public MaskFlags Mask { get; set; }
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public bool PreMultiplied { get; set; }
        public double Clip { get; set; }
        public double Gain { get; set; }
        public bool Invert { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.AddUInt8((int)MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddBoolArray(PreMultiplied);
            cmd.AddUInt16(1000, Clip);
            cmd.AddUInt16(1000, Gain);
            cmd.AddBoolArray(Invert);
            cmd.Pad(3);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            MixEffectIndex = (MixEffectBlockId)cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            PreMultiplied = cmd.GetBoolArray()[0];
            Clip = cmd.GetUInt16(0, 1000) / 1000d;
            Gain = cmd.GetUInt16(0, 1000) / 1000d;
            Invert = cmd.GetBoolArray()[0];
            cmd.Skip(3);
        }
    }
}