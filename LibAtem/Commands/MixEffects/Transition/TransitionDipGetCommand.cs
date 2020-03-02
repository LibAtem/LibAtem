using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TDpP", CommandDirection.ToClient, 4)]
    public class TransitionDipGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), UInt8]
        public uint Rate { get; set; }
        [Serialize(2), Enum16]
        public VideoSource Input { get; set; }
    }
}