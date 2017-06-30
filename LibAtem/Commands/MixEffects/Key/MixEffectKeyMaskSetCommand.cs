using System;
using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKMs")]
    public class MixEffectKeyMaskSetCommand : ICommand
    {
        [Flags]
        public enum MaskFlags
        {
            Enabled = 1 << 0,
            MaskTop = 1 << 1,
            MaskBottom = 1 << 2,
            MaskLeft = 1 << 3,
            MaskRight = 1 << 4,
        }

        public MaskFlags Mask { get; set; }
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public bool MaskEnabled { get; set; }
        public double MaskTop { get; set; }
        public double MaskBottom { get; set; }
        public double MaskLeft { get; set; }
        public double MaskRight { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int) Mask);
            cmd.AddUInt8((int) MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddBoolArray(MaskEnabled);
            cmd.AddInt16(1000, MaskTop);
            cmd.AddInt16(1000, MaskBottom);
            cmd.AddInt16(1000, MaskLeft);
            cmd.AddInt16(1000, MaskRight);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            Mask = (MaskFlags) cmd.GetUInt8();
            MixEffectIndex = (MixEffectBlockId)cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            MaskEnabled = cmd.GetBoolArray()[0];
            MaskTop = cmd.GetInt16(-9000, 9000) / 1000d;
            MaskBottom = cmd.GetInt16(-9000, 9000) / 1000d;
            MaskLeft = cmd.GetInt16(-16000, 16000) / 1000d;
            MaskRight = cmd.GetInt16(-16000, 16000) / 1000d;
        }
    }
}