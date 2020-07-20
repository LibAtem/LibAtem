using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeFS", CommandDirection.ToClient, 8)]
    public class MixEffectKeyFlyPropertiesGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }

        [Serialize(2), Bool]
        public bool IsASet { get; set; }

        [Serialize(3), Bool]
        public bool IsBSet { get; set; }

        [Serialize(4), Enum8]
        public FlyKeyLocation RunToInfinite { get; set; }

        [Serialize(5), Enum8]
        public FlyKeyKeyFrameType ActiveKeyFrame { get; set; }

        [Serialize(6), UInt8] // TODO - type of this
        public int IsAtKeyFrame { get; set; }
    }
}