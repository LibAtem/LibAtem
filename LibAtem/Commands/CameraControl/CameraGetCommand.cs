using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.CameraControl
{
    [CommandName("CCdP", CommandDirection.ToClient, 24)]
    public class CameraGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8]
        public uint CameraId { get; set; }

        [CommandId]
        [Serialize(1), Enum8]
        public CameraGroup CameraGroup { get; set; }

        [CommandId]
        [Serialize(2), UInt8]
        public uint Id { get; set; }

        //ToDo figure out data field (type and number of elements)
        //bound to have this all wrong. Will need to create class for each camera/group/parameter
    }
}