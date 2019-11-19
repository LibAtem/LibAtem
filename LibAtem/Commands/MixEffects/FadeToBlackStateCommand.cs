using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("FtbS", CommandDirection.ToClient, 4)]
    public class FadeToBlackStateCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), Bool]
        public bool IsFullyBlack { get; set; }
        [Serialize(2), Bool]
        public bool InTransition { get; set; }
        [Serialize(3), UInt8Range(0, 250)]
        public uint RemainingFrames { get; set; }
    }
}