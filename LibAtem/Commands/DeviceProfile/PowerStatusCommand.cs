using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("Powr", 4)]
    public class PowerStatusCommand : SerializableCommandBase
    {
        [Serializable(0), Bool(0)]
        public bool Pin1 { get; set; }
        [Serializable(0), Bool(1)]
        public bool Pin2 { get; set; }
    }
}