using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("CAuS", 4)]
    public class AuxSourceSetCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8]
        public uint Mask => 1;

        [Serializable(1), UInt8Range(0, 5)]
        public uint Id { get; set; }
        
        [Serializable(2), Enum16]
        public VideoSource Source { get; set; }
    }
}