using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKLm", 12)]
    public class MixEffectKeyLumaSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            PreMultiplied = 1 << 0,
            Clip = 1 << 1,
            Gain = 1 << 2,
            Invert = 1 << 3,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(2), UInt8]
        public uint KeyerIndex { get; set; }
        [Serialize(3), Bool]
        public bool PreMultiplied { get; set; }
        [Serialize(4), UInt16D(10, 0, 1000)]
        public double Clip { get; set; }
        [Serialize(6), UInt16D(10, 0, 1000)]
        public double Gain { get; set; }
        [Serialize(8), Bool]
        public bool Invert { get; set; }
    }
}