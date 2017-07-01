using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("TrPs", 8)]
    public class TransitionPositionGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(1), Bool]
        public bool InTransition { get; set; }
        [Serializable(2), UInt8Range(0, 250)]
        public uint RemainingFrames { get; set; }
        [Serializable(4), UInt16]
        public uint HandlePosition { get; set; }
    }
}