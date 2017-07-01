using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("DHVm", 4)]
    public class DownConvertAvailableModesCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public VideoMode CoreVideoMode { get; set; }

        [Serialize(1), Enum8]
        public VideoMode DownConvertedMode { get; set; }
    }
}