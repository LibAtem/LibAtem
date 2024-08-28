using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("StMw", CommandDirection.ToClient, 4)]
    public class MultiviewWindowOverlaySupportCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint MultiviewIndex { get; set; }
        [CommandId]
        [Serialize(1), UInt8Range(0, 15)]
        public uint WindowIndex { get; set; }

        [Serialize(2), Bool]
        public bool CurrentInputSupportsLabelOverlay { get; set; }
    }
}