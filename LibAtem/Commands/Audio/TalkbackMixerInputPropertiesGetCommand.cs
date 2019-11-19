using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    // Note: likely worked since v7.4, but no way to test
    [CommandName("TMIP", CommandDirection.ToClient, ProtocolVersion.V8_0, 8)]
    public class TalkbackMixerInputPropertiesGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public TalkbackChannel Channel { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public VideoSource Index { get; set; }

        // TODO 4 & 5 look like bools?
        [Serialize(6), Bool]
        public bool MuteSDI { get; set; }
    }
}