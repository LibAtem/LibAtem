using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    // Note: likely worked since v7.4, but no way to test
    [CommandName("_FAC", CommandDirection.ToClient, 4), NoCommandId]
    public class FairlightAudioMixerConfigCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint Inputs { get; set; }
        [Serialize(1), UInt8]
        public uint Monitors { get; set; }
    }
}