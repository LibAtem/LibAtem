using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("CVdM", 4), NoCommandId]
    public class VideoModeSetCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public VideoMode VideoMode { get; set; }
    }
}