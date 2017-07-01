using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMI", 12)]
    public class AudioMixerInputSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
           MixOption = 1 << 0, 
           Gain = 1 << 1,
           Balance = 1 << 2,
        }

        [Serializable(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serializable(2), Enum16]
        public AudioSource Index { get; set; }
        [Serializable(4), Enum8]
        public AudioMixOption MixOption { get; set; }
        [Serializable(6), Decibels]
        public double Gain { get; set; }
        [Serializable(8), Int16D(200, -10000, 10000)]
        public double Balance { get; set; }
    }
}