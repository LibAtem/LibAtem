using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("AEBP", CommandDirection.ToClient, 36)]
    public class FairlightMixerEqualizerBandGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public AudioSource Index { get; set; }
        
        [CommandId]
        [Serialize(16), UInt8Range(0, 5)]
        public uint Band { get; set; }
        [Serialize(17), Bool]
        public bool BandEnabled { get; set; }
        
        [Serialize(19), Enum8]
        public FairlightEqualizerBandShape Shape { get; set; }
        
        [Serialize(21), Enum8]
        public FairlightEqualizerFrequencyRange FrequencyRange { get; set; }
        
        [Serialize(24), UInt32RangeAttribute(30, 21700)]
        public uint Frequency { get; set; }
        [Serialize(28), Int32D(100, -2000, 2000)]
        public double Gain { get; set; }
        [Serialize(32), Int16D(100, 30, 1030)]
        public double QFactor { get; set; }
    }
}