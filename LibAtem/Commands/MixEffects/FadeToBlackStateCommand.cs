using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("FtbS", 4)]
    public class FadeToBlackStateCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serializable(1), Bool]
        public bool IsFullyBlack { get; set; }
        [Serializable(2), Bool]
        public bool InTransition { get; set; }
        [Serializable(3), UInt8Range(0, 250)]
        public uint RemainingFrames { get; set; }
    }
}