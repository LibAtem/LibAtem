using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("MvVM", 4)]
    public class MultiviewerAvailableModesCommand : SerializableCommandBase
    {
        [Serialize(0), Enum8]
        public VideoMode CoreVideoMode { get; set; }
        [Serialize(1), Enum8]
        public VideoMode MultiviewMode { get; set; }
    }
}