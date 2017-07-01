using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("FtbC", 4)]
    public class FadeToBlackRateSetCommand : SerializableCommandBase
    {
        [Serializable(1), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(2), UInt8Range(0, 250)]
        public uint Rate { get; set; }

        public override void Serialize(CommandBuilder cmd)
        {
            base.Serialize(cmd);
            cmd.Set(0, 0x01); // Mask Flag
        }
    }
}