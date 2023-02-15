using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("RFlK", CommandDirection.ToServer, 8)]
    public class MixEffectKeyFlyRunSetCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint Mask { get { return KeyFrame == FlyKeyKeyFrameType.RunToInfinite ? 2u : 0u; } }

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