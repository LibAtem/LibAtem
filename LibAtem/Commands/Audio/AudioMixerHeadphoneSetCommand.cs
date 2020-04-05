using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMH", CommandDirection.ToServer, 12), NoCommandId]
    public class AudioMixerHeadphoneSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Gain = 1 << 0,
            ProgramOutGain = 1 << 1,
            TalkbackGain = 1 << 2,
            SidetoneGain = 1 << 3,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [Serialize(2), Decibels]
        public double Gain { get; set; }
        [Serialize(4), Decibels]
        public double ProgramOutGain { get; set; }
        [Serialize(6), Decibels]
        public double TalkbackGain { get; set; }
        [Serialize(8), Decibels]
        public double SidetoneGain { get; set; }
    }
}