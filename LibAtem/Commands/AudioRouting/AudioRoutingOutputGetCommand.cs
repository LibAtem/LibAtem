using LibAtem.Common;
using LibAtem.Serialization;
using System;

namespace LibAtem.Commands.AudioRouting
{
    [CommandName("AROP", CommandDirection.ToClient, 80)]
    public class AudioRoutingOutputGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt32]
        public uint Id { get; set; }

        [Serialize(4), UInt32]
        public uint SourceId { get; set; }

        [Serialize(8), Enum16]
        public AudioPortType ExternalPortType { get; set; }

        [Serialize(10), Enum16]
        public AudioInternalPortType InternalPortType { get; set; }

        [Serialize(12), String(64)]
        public string Name { get; set; }

        public ushort AudioOutputId
        {
            get => (ushort)(Id >> 16);
        }

        public AudioChannelPair AudioChannelPair
        {
            get => (AudioChannelPair)(Id & 0xffff);
        }
    }
}