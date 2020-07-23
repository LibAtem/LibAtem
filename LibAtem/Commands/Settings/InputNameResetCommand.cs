using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("RInL", CommandDirection.ToServer, 4)]
    public class InputNameResetCommand: SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public VideoSource Id { get; set; }
    }
}