using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Talkback
{
    [CommandName("ATMP", CommandDirection.ToClient, 4)]
    public class TalkbackMixerPropertiesGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public TalkbackChannel Channel { get; set; }
        [Serialize(1), Bool]
        public bool MuteSDI { get; set; }
    }

}