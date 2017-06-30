using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("AuxS", 4)]
    public class AuxSourceGetCommand : SerializableCommandBase
    {
        [UInt8Range(0, 5)]
        [Serializable(0)]
        public uint Id { get; set; }

        [Enum16]
        [Serializable(2)]
        public VideoSource Source { get; set; }
    }
}