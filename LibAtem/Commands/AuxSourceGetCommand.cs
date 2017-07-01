using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("AuxS", 4)]
    public class AuxSourceGetCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8Range(0, 5)]
        public uint Id { get; set; }

        [Serialize(2), Enum16]
        public VideoSource Source { get; set; }
    }
}