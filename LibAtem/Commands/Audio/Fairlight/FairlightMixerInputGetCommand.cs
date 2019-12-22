using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FAIP", CommandDirection.ToServer, 16)]
    public class FairlightMixerInputGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public AudioSource Index { get; set; } // TODO - ensure the mics are valid
        
        [Serialize(2), UInt8]
        public uint InputType { get; set; }
        
        [Serialize(4), UInt16]
        public uint Rank { get; set; }
        
        [Serialize(6), UInt16]
        public uint ExternalType { get; set; }
        
        [Serialize(11), UInt8]
        public uint AvailableConfigs { get; set; }
        [Serialize(12), UInt8]
        public uint ActiveConfig { get; set; }
    }
}