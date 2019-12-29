using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects
{
    [CommandName("FCut", CommandDirection.ToServer, 4)]
    public class FadeToBlackCutCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }

        [Serialize(1), Bool]
        public bool IsFullyBlack { get; set; }
    }
}