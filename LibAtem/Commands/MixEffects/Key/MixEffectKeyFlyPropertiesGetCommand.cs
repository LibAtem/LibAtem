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
        public FlyKeyKeyFrameType RunningToKeyFrame { get; set; }
        
        [Serialize(5), Enum8]
        public FlyKeyLocation RunningToInfinite { get; set; }

        // This is a pretty meaningless value, as it is really the LastRunKeyFrame
        // [Serialize(6), Enum8]
        // public FlyKeyAtKeyFrame IsAtKeyFrame { get; set; }

        public override void Deserialize(ParsedByteArray cmd)
        {
            base.Deserialize(cmd);

            if (RunningToKeyFrame != FlyKeyKeyFrameType.RunToInfinite)
                RunningToInfinite = 0;
        }

        public override void Serialize(ByteArrayBuilder cmd)
        {
            if (RunningToKeyFrame != FlyKeyKeyFrameType.RunToInfinite)
                RunningToInfinite = 0;
            
            base.Serialize(cmd);
        }
    }
}