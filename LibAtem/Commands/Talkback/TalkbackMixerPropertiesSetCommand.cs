using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Talkback
{
    [CommandName("CATM", CommandDirection.ToServer, 4)]
    public class TalkbackMixerPropertiesSetCommand : SerializableCommandBase
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

        [Serialize(2), Bool]
        public bool MuteSDI { get; set; }
    }

}