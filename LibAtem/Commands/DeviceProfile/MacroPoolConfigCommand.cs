using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_MAC", CommandDirection.ToClient, 4), NoCommandId]
    public class MacroPoolConfigCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint MacroCount { get; set; }
    }
}