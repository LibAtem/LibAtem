using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("VidM", 4)]
    public class VideoModeGetCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public VideoMode VideoMode { get; set; }
    }
}