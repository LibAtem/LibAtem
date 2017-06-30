using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("MvVM", 4)]
    public class MultiviewerAvailableModesCommand : SerializableCommandBase
    {
        [Serializable(0), Enum8]
        public VideoMode CoreVideoMode { get; set; }
        [Serializable(1), Enum8]
        public VideoMode MultiviewMode { get; set; }
    }
}