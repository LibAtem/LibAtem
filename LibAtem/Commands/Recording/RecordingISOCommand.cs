using LibAtem.Serialization;

namespace LibAtem.Commands.Recording
{
    [CommandName("ISOi", CommandDirection.Both, 4), NoCommandId]
    public class RecordingISOCommand : SerializableCommandBase
    {
        [Serialize(0), Bool]
        public bool ISORecordAllInputs { get; set; }

    }
}