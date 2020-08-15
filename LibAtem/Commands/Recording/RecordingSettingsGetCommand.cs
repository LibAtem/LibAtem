using LibAtem.Serialization;

namespace LibAtem.Commands.Recording
{
    [CommandName("RMSu", CommandDirection.ToClient, ProtocolVersion.V8_1_1, 140), NoCommandId]
    public class RecordingSettingsGetCommand : SerializableCommandBase
    {
        [Serialize(0), String(128)]
        public string Filename { get; set; }

        [Serialize(128), UInt32]
        public uint WorkingSet1DiskId { get; set; }
        [Serialize(132), UInt32]
        public uint WorkingSet2DiskId { get; set; }

        [Serialize(136), Bool]
        public bool RecordInAllCameras { get; set; }
    }
}