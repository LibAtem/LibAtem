using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TDpP", 4)]
    public class TransitionDipGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(1), UInt8]
        public uint Rate { get; set; }
        [Serializable(2), Enum16]
        public VideoSource Input { get; set; }
    }
}