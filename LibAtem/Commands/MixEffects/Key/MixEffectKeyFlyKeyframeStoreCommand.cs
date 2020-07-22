using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("SFKF", CommandDirection.ToServer, 4)]
    public class MixEffectKeyFlyKeyframeStoreCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        [CommandId]
        [Serialize(2), Enum8]
        public FlyKeyKeyFrameId KeyFrame { get; set; }
    }
}