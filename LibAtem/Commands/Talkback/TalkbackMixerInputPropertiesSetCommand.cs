using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Talkback
{
    [CommandName("CTIP", CommandDirection.ToServer, ProtocolVersion.V8_0, 8)]
    public class TalkbackMixerInputPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            MuteSDI = 1 << 0,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [CommandId]
        [Serialize(1), Enum8]
        public TalkbackChannel Channel { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public VideoSource Index { get; set; }

        [Serialize(4), Bool]
        public bool MuteSDI { get; set; }
    }
}