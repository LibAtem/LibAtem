using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.CameraControl;
{
    [CommandName("CCdP", CommandDirection.ToClient, 24)]
    public class CameraGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public CameraId Id { get; set; }

        [CommandId]
        [Serialize(1), Enum8]
        public Group CameraGroup { get; set; }

        [CommandId]
        [Serialize(2), Enum8]
        public Parameter Id { get; set; }

        #ToDo figure out data field (type and number of elements)
        #bound to have this all wrong. Will need to create class for each group/parameter
    }
}