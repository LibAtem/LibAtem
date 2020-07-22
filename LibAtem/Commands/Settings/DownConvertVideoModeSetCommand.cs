using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("CDHV", CommandDirection.ToServer, 4)]
    public class DownConvertVideoModeSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public VideoMode CoreVideoMode { get; set; }

        [Serialize(1), Enum8]
        public VideoMode DownConvertedMode { get; set; }
    }
}