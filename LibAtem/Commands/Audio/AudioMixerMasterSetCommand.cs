using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMM", 8), NoCommandId]
    public class AudioMixerMasterSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Gain = 1 << 0,
            Balance = 1 << 1, //??
            ProgramOutFollowFadeToBlack = 1 << 2,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serialize(2), Decibels]
        public double Gain { get; set; }
        [Serialize(4), Int16D(200, -10000, 10000)]
        public double Balance { get; set; }
        [Serialize(6), Bool]
        public bool ProgramOutFollowFadeToBlack { get; set; }
    }
}