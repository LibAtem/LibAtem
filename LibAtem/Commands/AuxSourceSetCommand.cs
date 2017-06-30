using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("CAuS", 4)]
    public class AuxSourceSetCommand : SerializableCommandBase
    {
        [UInt8]
        [Serializable(0)]
        public uint Mask => 1;

        [UInt8Range(0, 5)]
        [Serializable(1)]
        public uint Id { get; set; }

        [Enum16]
        [Serializable(2)]
        public VideoSource Source { get; set; }
    }
}