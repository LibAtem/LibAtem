using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMM", 8)]
    public class AudioMixerMasterSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Gain = 1 << 0,
            Balance = 1 << 1, //??
            ProgramOutFollowFadeToBlack = 1 << 2,
        }

        [Serializable(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serializable(2), Decibels]
        public double Gain { get; set; }
        [Serializable(4), Int16D(200, -10000, 10000)]
        public double Balance { get; set; }
        [Serializable(6), Bool]
        public bool ProgramOutFollowFadeToBlack { get; set; }
    }
}