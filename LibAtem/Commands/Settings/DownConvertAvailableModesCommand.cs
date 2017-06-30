using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("DHVm", 4)]
    public class DownConvertAvailableModesCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public VideoMode CoreVideoMode { get; set; }

        [Serializable(1), Enum8]
        public VideoMode DownConvertedMode { get; set; }
    }
}