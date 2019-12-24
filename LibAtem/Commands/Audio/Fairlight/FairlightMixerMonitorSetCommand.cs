using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CFMH", CommandDirection.ToServer, 36), NoCommandId]
    public class FairlightMixerMonitorSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Gain = 1 << 0,
            InputMasterGain = 1 << 1,
            InputTalkbackGain = 1 << 3,
            InputSidetoneGain = 1 << 7,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [Serialize(4), Int32D(100, -12141, 600)]
        public double Gain { get; set; }

        [Serialize(8), Int32D(100, -6000, 600)]
        public double InputMasterGain { get; set; }
        [Serialize(16), Int32D(100, -6000, 0)]
        public double InputTalkbackGain { get; set; }
        [Serialize(32), Int32D(100, -6000, 600)]
        public double InputSidetoneGain { get; set; }
    }
}