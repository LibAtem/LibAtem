using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeBP", 20)]
    public class MixEffectKeyPropertiesGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId MixEffectIndex { get; set; }
        [Serializable(1), UInt8]
        public uint KeyerIndex { get; set; }
        [Serializable(2), Enum8]
        public MixEffectKeyType Mode { get; set; }
        [Serializable(5), Bool]
        public bool FlyEnabled { get; set; }
        [Serializable(6), Enum16]
        public VideoSource FillSource { get; set; }
        [Serializable(8), Enum16]
        public VideoSource CutSource { get; set; }

        [Serializable(10), Bool]
        public bool MaskEnabled { get; set; }
        [Serializable(12), Int16D(1000, -9000, 9000)]
        public double MaskTop { get; set; }
        [Serializable(14), Int16D(1000, -9000, 9000)]
        public double MaskBottom { get; set; }
        [Serializable(16), Int16D(1000, -16000, 16000)]
        public double MaskLeft { get; set; }
        [Serializable(18), Int16D(1000, -16000, 16000)]
        public double MaskRight { get; set; }

        public override void Serialize(CommandBuilder cmd)
        {
            base.Serialize(cmd);

            cmd.Set(3); // ??
            cmd.Set(4); // ??
        }
    }
}