using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_AMC", CommandDirection.ToClient, 4), NoCommandId]
    public class AudioMixerConfigCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint Inputs { get; set; }
        [Serialize(1), UInt8]
        public uint Monitors { get; set; }
        [Serialize(2), UInt8]
        public uint Headphones { get; set; }
    }
}