using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("MvIn", 8)]
    public class MultiviewWindowInputGetCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8]
        public uint MultiviewIndex { get; set; }
        [Serializable(1), UInt8Range(0, 9)]
        public uint WindowIndex { get; set; }
        [Serializable(2), Enum16]
        public VideoSource Source { get; set; }
    }
}