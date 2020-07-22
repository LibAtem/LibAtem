using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("DHVm", CommandDirection.ToClient, 4)]
    public class DownConvertVideoModeGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public VideoMode CoreVideoMode { get; set; }

        [Serialize(1), Enum8]
        public VideoMode DownConvertedMode { get; set; }
    }
}