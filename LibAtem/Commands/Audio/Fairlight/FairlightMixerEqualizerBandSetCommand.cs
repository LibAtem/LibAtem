using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CEBP", CommandDirection.ToServer, 32)]
    public class FairlightMixerEqualizerBandSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            BandEnabled = 1 << 0,
            Shape = 1 << 1,
            FrequencyRange = 1 << 2,
            Frequency = 1 << 3,
            Gain = 1 << 4,
            QFactor = 1 << 5,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(2), Enum16]
        public AudioSource Index { get; set; }
        
        [CommandId]
        [Serialize(16), UInt8Range(0, 5)]
        public uint Band { get; set; }
        [Serialize(17), Bool]
        public bool BandEnabled { get; set; }
        [Serialize(18), Enum8]
        public FairlightEqualizerBandShape Shape { get; set; }
        [Serialize(19), Enum8]
        public FairlightEqualizerFrequencyRange FrequencyRange { get; set; }
        [Serialize(20), UInt32RangeAttribute(30, 21700)]
        public uint Frequency { get; set; }
        [Serialize(24), Int32D(100, -2000, 2000)]
        public double Gain { get; set; }
        [Serialize(28), Int16D(100, 30, 1030)]
        public double QFactor { get; set; }
    }
}