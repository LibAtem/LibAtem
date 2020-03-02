using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CFSP", CommandDirection.ToServer, 48)]
    public class FairlightMixerSourceSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            FramesDelay = 1 << 0,
            Gain = 1 << 1,
            StereoSimulation = 1 << 2,
            EqualizerEnabled = 1 << 3,
            EqualizerGain = 1 << 4,
            MakeUpGain = 1 << 5,
            Balance = 1 << 6,
            FaderGain = 1 << 7,
            MixOption = 1 << 8,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public AudioSource Index { get; set; }

        [CommandId]
        [Serialize(8), Int64]
        public long SourceId { get; set; }

        [Serialize(16), UInt8]
        public uint FramesDelay { get; set; }

        // TODO - mono vs stereo

        [Serialize(20), Int32D(100, -10000, 600, true)]
        public double Gain { get; set; }

        [Serialize(24), Int16D(100, 0, 10000)]
        public double StereoSimulation { get; set; }
        
        [Serialize(26), Bool]
        public bool EqualizerEnabled { get; set; }
        [Serialize(28), Int32D(100, -2000, 2000)]
        public double EqualizerGain { get; set; }
        [Serialize(32), Int32D(100, 0, 2000)]
        public double MakeUpGain { get; set; }
        [Serialize(36), Int16D(100, -10000, 10000)]
        public double Balance { get; set; }
        [Serialize(40), Int32D(100.0, -10000, 1000, true)]
        public double FaderGain { get; set; }
        [Serialize(44), Enum8]
        public FairlightAudioMixOption MixOption { get; set; }

    }
}