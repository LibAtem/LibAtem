using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeBP", 20)]
    public class MixEffectKeyPropertiesGetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serialize(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serialize(2), Enum8]
        public MixEffectKeyType Mode { get; set; }
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

        public override void Serialize(CommandBuilder cmd)
        {
            base.Serialize(cmd);

            cmd.Set(3); // ??
            cmd.Set(4); // ??
        }
    }
}