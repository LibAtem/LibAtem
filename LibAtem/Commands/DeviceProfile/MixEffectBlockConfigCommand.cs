using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_MeC", 4)]
    public class MixEffectBlockConfigCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(1), UInt8]
        public uint KeyCount { get; set; }
    }
}