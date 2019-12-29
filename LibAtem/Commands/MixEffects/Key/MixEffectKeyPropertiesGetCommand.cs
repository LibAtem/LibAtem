using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeBP", CommandDirection.ToClient, 20)]
    public class MixEffectKeyPropertiesGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public UpstreamKeyId KeyerIndex { get; set; }
        [Serialize(2), Enum8]
        public MixEffectKeyType KeyType { get; set; }
        [Serialize(5), Bool]
        public bool FlyEnabled { get; set; }
        [Serialize(6), Enum16]
        public VideoSource FillSource { get; set; }
        [Serialize(8), Enum16]
        public VideoSource CutSource { get; set; }

        [Serialize(10), Bool]
        public bool MaskEnabled { get; set; }
        [Serialize(12), Int16D(1000, -9000, 9000)]
        public double MaskTop { get; set; }
        [Serialize(14), Int16D(1000, -9000, 9000)]
        public double MaskBottom { get; set; }
        [Serialize(16), Int16D(1000, -16000, 16000)]
        public double MaskLeft { get; set; }
        [Serialize(18), Int16D(1000, -16000, 16000)]
        public double MaskRight { get; set; }

        public override void Serialize(ByteArrayBuilder cmd)
        {
            base.Serialize(cmd);

            cmd.Set(3); // ??
            cmd.Set(4); // ??
        }
    }
}