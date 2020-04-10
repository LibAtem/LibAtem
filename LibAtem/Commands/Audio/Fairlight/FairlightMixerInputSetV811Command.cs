using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CFIP", CommandDirection.ToServer, ProtocolVersion.V8_1_1, 8)]
    public class FairlightMixerInputSetV811Command : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            ActiveConfiguration = 1 << 0,
            ActiveInputLevel = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public AudioSource Index { get; set; }

        [Serialize(4), Enum8]
        public FairlightInputConfiguration ActiveConfiguration { get; set; }

        [Serialize(5), Enum8]
        public FairlightAnalogInputLevel ActiveInputLevel { get; set; }
    }
}