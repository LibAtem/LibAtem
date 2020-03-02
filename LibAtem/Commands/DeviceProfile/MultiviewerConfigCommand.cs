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

        // [Serialize(2), UInt8]
        // public uint Tmp2 { get; set; }
        
        [Serialize(3), Bool]
        public bool CanRouteInputs { get; set; }

        // [Serialize(4), UInt8]
        // public uint Tmp4 { get; set; }

        // [Serialize(6), UInt8]
        // public uint Tmp6 { get; set; }

        [Serialize(5), Bool]
        public bool CanSwapPreviewProgram { get; set; }

        [Serialize(7), Bool]
        public bool CanToggleSafeArea { get; set; }

    }
}