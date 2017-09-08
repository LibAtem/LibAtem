using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("PrvI", 8)]
    public class PreviewInputGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(2), Enum16]
        public VideoSource Source { get; set; }

        public override void Serialize(ByteArrayBuilder cmd)
        {
            base.Serialize(cmd);
            cmd.Set(4, 0x00, 0x0a, 0x13, 0x01); // TODO
        }
    }
}