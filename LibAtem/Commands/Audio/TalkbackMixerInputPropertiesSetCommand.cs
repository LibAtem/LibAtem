using LibAtem.Common;
using LibAtem.Serialization;
using System;

namespace LibAtem.Commands.Audio
{
    // Note: likely worked since v7.4, but no way to test
    [CommandName("CTIP", ProtocolVersion.V8_0, 8)]
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

        [Serialize(6), Bool]
        public bool MuteSDI { get; set; }

        public override void Deserialize(ParsedByteArray cmd)
        {
            base.Deserialize(cmd);
            // Console.WriteLine("CTIP: {0}", BitConverter.ToString(cmd.Body));
        }
    }
}