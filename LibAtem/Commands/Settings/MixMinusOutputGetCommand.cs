using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("MMOP", CommandDirection.ToClient, 12)]
    public class MixMinusOutputGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint Id { get; set; }

        [Serialize(1), Enum8]
        public MixMinusMode Mode { get; set; }
        [Serialize(2), Enum8]
        public MixMinusMode SupportedModes { get; set; }

        [Serialize(6), Enum16]
        public AudioSource AudioInputId { get; set; }

        // TODO - more must be used for something
    }
}