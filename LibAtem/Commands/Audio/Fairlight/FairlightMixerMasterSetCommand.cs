using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CFMP", CommandDirection.ToServer, 20), NoCommandId]
    public class FairlightMixerMasterSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            EqualizerEnabled = 1 << 0,
            EqualizerGain = 1 << 1,
            MakeUpGain = 1 << 2,
            Gain = 1 << 3,
            FollowFadeToBlack = 1 << 4,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        
        [Serialize(1), Bool]
        public bool EqualizerEnabled { get; set; }
        [Serialize(4), Int32D(100, -2000, 2000)]
        public double EqualizerGain { get; set; }
        [Serialize(8), Int32D(100, 0, 2000)]
        public double MakeUpGain { get; set; }
        [Serialize(12), Int32D(100, -10000, 600, true)]
        public double Gain { get; set; }
        [Serialize(16), Bool]
        public bool FollowFadeToBlack { get; set; }
    }
}