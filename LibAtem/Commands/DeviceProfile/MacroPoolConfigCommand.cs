using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_MAC", 4)]
    public class MacroPoolConfigCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8]
        public uint MacroCount { get; set; }
    }
}