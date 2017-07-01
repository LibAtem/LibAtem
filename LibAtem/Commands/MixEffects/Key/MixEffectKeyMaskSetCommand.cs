using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKMs", 12)]
    public class MixEffectKeyMaskSetCommand : SerializableCommandBase
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

        [Serializable(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serializable(1), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serializable(2), UInt8]
        public uint KeyerIndex { get; set; }
        [Serializable(3), Bool]
        public bool MaskEnabled { get; set; }
        [Serializable(4), Int16D(1000, -9000, 9000)]
        public double MaskTop { get; set; }
        [Serializable(6), Int16D(1000, -9000, 9000)]
        public double MaskBottom { get; set; }
        [Serializable(8), Int16D(1000, -16000, 16000)]
        public double MaskLeft { get; set; }
        [Serializable(10), Int16D(1000, -16000, 16000)]
        public double MaskRight { get; set; }
    }
}