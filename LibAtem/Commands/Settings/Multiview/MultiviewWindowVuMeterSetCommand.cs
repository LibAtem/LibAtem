using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("VuMS", 4)]
    public class MultiviewWindowVuMeterSetCommand : SerializableCommandBase
    {
        [Serializable(0), UInt8]
        public uint MultiviewIndex { get; set; }
        [Serializable(1), UInt8Range(0, 9)]
        public uint WindowIndex { get; set; }
        [Serializable(2), Bool]
        public bool VuEnabled { get; set; }
    }
}