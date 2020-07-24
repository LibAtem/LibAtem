using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FAIP", CommandDirection.ToClient, ProtocolVersion.V8_1_1, 16)]
    public class FairlightMixerInputGetV811Command : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public AudioSource Index { get; set; }

        [Serialize(2), Enum8]
        public FairlightInputType InputType { get; set; }

        [Serialize(6), Enum16]
        public AudioPortType ExternalPortType { get; set; }
        
        [Serialize(9), Enum8]
        public FairlightInputConfiguration SupportedConfigurations { get; set; }
        [Serialize(10), Enum8]
        public FairlightInputConfiguration ActiveConfiguration { get; set; }

        [Serialize(11), Enum8]
        public FairlightAnalogInputLevel SupportedInputLevels { get; set; }
        [Serialize(12), Enum8]
        public FairlightAnalogInputLevel ActiveInputLevel { get; set; }
    }
}