using LibAtem.Serialization;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("SaMw", CommandDirection.Both, ProtocolVersion.V8_0, 4)]
    public class MultiviewWindowSafeAreaCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint MultiviewIndex { get; set; }
        [CommandId]
        [Serialize(1), UInt8Range(0, 15)]
        public uint WindowIndex { get; set; }
        [Serialize(2), Bool]
        public bool SafeAreaEnabled { get; set; }
    }
}