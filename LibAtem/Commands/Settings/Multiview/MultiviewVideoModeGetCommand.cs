using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("MvVM", CommandDirection.ToClient, 4)]
    public class MultiviewVideoModeGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public VideoMode CoreVideoMode { get; set; }
        [Serialize(1), Enum8]
        public VideoMode MultiviewMode { get; set; }
    }
}