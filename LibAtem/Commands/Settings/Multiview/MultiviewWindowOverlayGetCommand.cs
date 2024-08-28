using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("MvOv", CommandDirection.ToClient, 4)]
    public class MultiviewWindowOverlayGetCommand: SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint MultiviewIndex { get; set; }
        [CommandId]
        [Serialize(1), UInt8Range(0, 15)]
        public uint WindowIndex { get; set; }

        [Serialize(3), Bool(0)]
        public bool LabelVisible { get; set; }

        [Serialize(3), Bool(1)]
        public bool BorderVisible { get; set; }
    }
}