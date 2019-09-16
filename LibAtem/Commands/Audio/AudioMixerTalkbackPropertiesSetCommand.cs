using LibAtem.Serialization;
using System;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMT", 4), NoCommandId]
    public class AudioMixerTalkbackPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            MuteSDI = 1 << 0,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [Serialize(2), Bool]
        public bool MuteSDI { get; set; }
    }

}