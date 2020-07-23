using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("MvIn", CommandDirection.ToClient, 8)]
    public class MultiviewWindowInputGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint MultiviewIndex { get; set; }
        [CommandId]
        [Serialize(1), UInt8Range(0, 15)]
        public uint WindowIndex { get; set; }
        [Serialize(2), Enum16]
        public VideoSource Source { get; set; }

        [Serialize(4), Bool]
        public bool SupportVuMeter { get; set; }
        [Serialize(5), Bool]
        public bool SupportsSafeArea { get; set; }
    }
}