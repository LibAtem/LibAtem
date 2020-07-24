using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FAIP", CommandDirection.ToClient, 16)]
    public class FairlightMixerInputGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public AudioSource Index { get; set; }
        
        [Serialize(2), Enum8]
        public FairlightInputType InputType { get; set; }

        [Serialize(6), Enum16]
        public AudioPortType ExternalPortType { get; set; }

        [Serialize(8), Bool]
        public bool SupportsRcaToXlr { get; set; }
        [Serialize(9), Bool]
        public bool RcaToXlrEnabled { get; set; }
        
        [Serialize(11), Enum8]
        public FairlightInputConfiguration SupportedConfigurations { get; set; }
        [Serialize(12), Enum8]
        public FairlightInputConfiguration ActiveConfiguration { get; set; }
    }
}