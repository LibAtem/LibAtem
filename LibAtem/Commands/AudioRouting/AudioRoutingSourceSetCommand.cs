using LibAtem.Serialization;
using System;

namespace LibAtem.Commands.AudioRouting
{
    [CommandName("ARSC", CommandDirection.ToServer, 72)]
    public class AudioRoutingSourceSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Name = 1 << 0,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(4), UInt32]
        public uint Id { get; set; }

        [Serialize(8), String(64)]
        public string Name { get; set; }
    }
}