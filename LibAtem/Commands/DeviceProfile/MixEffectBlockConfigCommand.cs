using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_MeC", CommandDirection.ToClient, 4)]
    public class MixEffectBlockConfigCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), UInt8]
        public uint KeyCount { get; set; }
    }
}