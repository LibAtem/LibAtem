using LibAtem.Serialization;

namespace LibAtem.Commands.Recording
{
    [CommandName("ISOi", CommandDirection.Both, ProtocolVersion.V8_1_1, 4), NoCommandId]
    public class RecordingISOCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool ISORecordAllInputs { get; set; }

    }
}