using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("MvPr", 4)]
    public class MultiviewPropertiesGetCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8Range(0, 9)]
        public uint MultiviewIndex { get; set; }
        [Serializable(1), Enum8]
        public MultiViewLayout Layout { get; set; }
        [Serializable(2), Bool]
        public bool SafeAreaEnabled { get; set; }
        [Serializable(3), Bool]
        public bool ProgramPreviewSwapped { get; set; }
    }
}