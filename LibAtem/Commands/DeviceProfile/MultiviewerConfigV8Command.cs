using LibAtem.Serialization;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_MvC", CommandDirection.ToClient, ProtocolVersion.V8_0, 12), NoCommandId]
    public class MultiviewerConfigV8Command : SerializableCommandBase
    {
        [Serialize(0), UInt8]
        public uint Count { get; set; }
        [Serialize(1), UInt8]
        public uint WindowCount { get; set; }

        // [Serialize(2), Bool]
        // public bool Tmp2 { get; set; }
        [Serialize(3), Bool]
        public bool CanRouteWindows { get; set; }

        // TODO - order of these is incorrect
        [Serialize(5), Bool]
        public bool CanSwapPreviewProgram { get; set; } // Not 7
        [Serialize(6), Bool]
        public bool SupportsVuMeters { get; set; }
        [Serialize(7), Bool]
        public bool CanToggleSafeArea { get; set; }

        [Serialize(9), Bool]
        public bool SupportsQuadrants { get; set; }

        // [Serialize(8), UInt8]
        // public uint Tmp8 { get; set; }
        // [Serialize(9), UInt8]
        // public uint Tmp9 { get; set; }

    }
}