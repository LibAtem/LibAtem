using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("RFlK", CommandDirection.ToServer, 8)]
    public class MixEffectKeyFlyRunSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            KeyFrame = 1 << 0,
            RunToInfinite = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(2), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        
        [Serialize(4), Enum8]
        public FlyKeyKeyFrameType KeyFrame { get; set; }

        [Serialize(5), Enum8]
        public FlyKeyLocation RunToInfinite { get; set; }
    }
}