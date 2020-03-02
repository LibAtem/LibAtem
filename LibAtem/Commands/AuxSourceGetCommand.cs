using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    [CommandName("AuxS", CommandDirection.ToClient, 4)]
    public class AuxSourceGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public AuxiliaryId Id { get; set; }

        [Serialize(2), Enum16]
        public VideoSource Source { get; set; }
    }
}