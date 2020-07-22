using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("CMVM", CommandDirection.ToServer, 4)]
    public class MultiviewVideoModeSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public VideoMode CoreVideoMode { get; set; }
        [Serialize(1), Enum8]
        public VideoMode MultiviewMode { get; set; }
    }
}