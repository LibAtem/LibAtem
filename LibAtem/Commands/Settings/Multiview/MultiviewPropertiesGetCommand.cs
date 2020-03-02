using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("MvPr", CommandDirection.ToClient, 4)]
    public class MultiviewPropertiesGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8Range(0, 1)]
        public uint MultiviewIndex { get; set; }
        [Serialize(1), Enum8]
        public MultiViewLayout Layout { get; set; }
        [Serialize(2), Bool]
        public bool SafeAreaEnabled { get; set; }
        [Serialize(3), Bool]
        public bool ProgramPreviewSwapped { get; set; }
    }
}