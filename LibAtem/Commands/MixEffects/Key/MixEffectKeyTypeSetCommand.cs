using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("CKTp", 8)]
    public class MixEffectKeyTypeSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Type = 1 << 0,
            FlyEnabled = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(2), UInt8]
        public uint KeyerIndex { get; set; }
        [Serialize(3), Enum8]
        public MixEffectKeyType KeyType { get; set; }
        [Serialize(4), Bool]
        public bool FlyEnabled { get; set; }
    }
}