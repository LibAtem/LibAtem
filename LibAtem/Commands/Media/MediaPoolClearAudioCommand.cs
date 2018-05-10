using LibAtem.Serialization;

namespace LibAtem.Commands.Media
{
    [CommandName("CMPA", 4)]
    public class MediaPoolClearAudioCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint Index { get; set; } 
    }
}