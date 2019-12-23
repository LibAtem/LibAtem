using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CFIP", CommandDirection.ToClient, 8)]
    public class FairlightMixerInputSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            // ?? = 1 << 0,
            ActiveConfiguration = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public AudioSource Index { get; set; }
        
        [Serialize(5), Enum8]
        public FairlightInputConfiguration ActiveConfiguration { get; set; }
    }
}