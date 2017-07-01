using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TMxP", 4)]
    public class TransitionMixGetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), UInt8]
        public uint Rate { get; set; }

        public override void Serialize(CommandBuilder cmd)
        {
            base.Serialize(cmd);

            cmd.Set(2, 0x46, 0x6f); // TODO are these pad or real?
        }
    }
}