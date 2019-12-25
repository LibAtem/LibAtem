using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CMPP", CommandDirection.ToServer, 4), NoCommandId]
    public class FairlightMixerMasterPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            AudioFollowVideoCrossfadeTransitionEnabled = 1 << 0,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serialize(1), Bool]
        public bool AudioFollowVideoCrossfadeTransitionEnabled { get; set; }
    }
}