using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Settings
{
    [CommandName("CMMP", CommandDirection.ToServer, 8)]
    public class MixMinusOutputSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Mode = 1 << 0,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(1), UInt8]
        public uint Id { get; set; }

        [Serialize(2), Enum8]
        public MixMinusMode Mode { get; set; }

        // TODO - more must be used for something
    }
}