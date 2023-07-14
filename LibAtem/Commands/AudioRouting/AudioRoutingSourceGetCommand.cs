using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.AudioRouting
{
    [CommandName("ARSP", CommandDirection.ToClient, 76)]
    public class AudioRoutingSourceGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt32]
        public uint Id { get; set; }

        [Serialize(4), Enum16]
        public AudioPortType ExternalPortType { get; set; }

        [Serialize(6), Enum16]
        public AudioInternalPortType InternalPortType { get; set; }


        [Serialize(8), String(64)] // TODO Length
        public string Name { get; set; }

        public long AudioInputId
        {
            get => (ushort)(Id >> 16); // TODO - this isnt right
        }

        public AudioChannelPair AudioChannelPair
        {
            get => (AudioChannelPair)(Id & 0xffff);
        }
    }
}