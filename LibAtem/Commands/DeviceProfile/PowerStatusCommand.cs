using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("Powr", CommandDirection.ToClient, 4), NoCommandId]
    public class PowerStatusCommand : SerializableCommandBase
    {
        [Serialize(0), Bool(0)]
        public bool Pin1 { get; set; }
        [Serialize(0), Bool(1)]
        public bool Pin2 { get; set; }
    }
}