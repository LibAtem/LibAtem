using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_AMC", 4)]
    public class AudioMixerConfigCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8]
        public uint Inputs { get; set; }
        [Serializable(1), Bool]
        public bool HasMonitor { get; set; }
    }
}