using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMm", 12)]
    public class AudioMixerMonitorSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
           Enabled = 1 << 0,
            Gain = 1 << 1,
            Mute = 1 << 2,
            Solo = 1 << 3,
            SoloSource = 1 << 4,
            Dim = 1 << 5,
        }

        [Serializable(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serializable(1), Bool]
        public bool Enabled { get; set; }
        [Serializable(2), Decibels]
        public double Gain { get; set; }
        [Serializable(4), Bool]
        public bool Mute { get; set; }
        [Serializable(5), Bool]
        public bool Solo { get; set; }
        [Serializable(6), Enum16]
        public AudioSource SoloSource { get; set; }
        [Serializable(8), Bool]
        public bool Dim { get; set; }
    }
}