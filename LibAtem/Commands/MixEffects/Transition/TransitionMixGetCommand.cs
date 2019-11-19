using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TMxP", CommandDirection.ToClient, 4)]
    public class TransitionMixGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), UInt8]
        public uint Rate { get; set; }

        public override void Serialize(ByteArrayBuilder cmd)
        {
            base.Serialize(cmd);

            cmd.Set(2, 0x46, 0x6f); // TODO are these pad or real?
        }
    }
}