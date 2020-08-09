using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Talkback
{
    [CommandName("TMIP", CommandDirection.ToClient, ProtocolVersion.V8_0, 8)]
    public class TalkbackMixerInputPropertiesGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public TalkbackChannel Channel { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public VideoSource Index { get; set; }

        [Serialize(4), Bool]
        public bool InputCanMuteSDI { get; set; }
        [Serialize(5), Bool]
        public bool CurrentInputSupportsMuteSDI { get; set; }
        [Serialize(6), Bool]
        public bool MuteSDI { get; set; }
    }
}