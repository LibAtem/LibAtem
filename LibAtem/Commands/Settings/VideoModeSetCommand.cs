using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("CVdM", 4)]
    public class VideoModeSetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public VideoMode VideoMode { get; set; }
    }
}