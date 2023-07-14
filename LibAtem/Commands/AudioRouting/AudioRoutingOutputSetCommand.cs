using LibAtem.Serialization;
using System;

namespace LibAtem.Commands.AudioRouting
{
    [CommandName("AROC", CommandDirection.ToServer, 76)]
    public class AudioRoutingOutputSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            SourceId = 1 << 0,
            Name = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(4), UInt32]
        public uint Id { get; set; }

        [Serialize(8), UInt32]
        public uint SourceId { get; set; }

        [Serialize(12), String(64)]
        public string Name { get; set; }
    }
}