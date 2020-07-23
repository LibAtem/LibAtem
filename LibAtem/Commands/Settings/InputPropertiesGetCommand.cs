using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("InPr", CommandDirection.ToClient, 36)]
    public class InputPropertiesGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public VideoSource Id { get; set; }
        [Serialize(2), String(20)]
        public string LongName { get; set; }
        [Serialize(22), String(4)]
        public string ShortName { get; set; }
        [Serialize(26), Bool]
        public bool AreNamesDefault { get; set; }

        [Serialize(28), Enum16]
        public ExternalPortTypeFlags2 AvailableExternalPorts { get; set; }
        [Serialize(30), Enum16]
        public ExternalPortTypeFlags2 ExternalPortType { get; set; }
        [Serialize(32), Enum8]
        public InternalPortType InternalPortType { get; set; }
        [Serialize(34), Enum8]
        public SourceAvailability SourceAvailability { get; set; }

        [Serialize(35), Enum8]
        public MeAvailability MeAvailability { get; set; }
    }
}