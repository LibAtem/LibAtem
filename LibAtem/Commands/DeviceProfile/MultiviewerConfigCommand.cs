using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_MvC", CommandDirection.ToClient, 8), NoCommandId]
    public class MultiviewerConfigCommand : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint Count { get; set; }
        [Serialize(1), UInt8]
        public uint WindowCount { get; set; }

        // TODO - order of these is incorrect
        [Serialize(2), Bool]
        public bool CanRouteInputs { get; set; }
        [Serialize(3), Bool]
        public bool Unknown { get; set; }

        // TODO - order of these is incorrect
        [Serialize(5), Bool]
        public bool SupportsVuMeters { get; set; }
        [Serialize(6), Bool]
        public bool CanToggleSafeArea { get; set; }
        [Serialize(7), Bool]
        public bool CanSwapPreviewProgram { get; set; }
    }
}