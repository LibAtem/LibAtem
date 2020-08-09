using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("AMBP", CommandDirection.ToClient, 20)]
    public class 
        FairlightMixerMasterEqualizerBandGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), UInt8Range(0, 5)]
        public uint Band { get; set; }
        [Serialize(1), Bool]
        public bool BandEnabled { get; set; }
        [Serialize(2), Enum8]
        public FairlightEqualizerBandShape SupportedShapes { get; set; }

        [Serialize(3), Enum8]
        public FairlightEqualizerBandShape Shape { get; set; }

        [Serialize(4), Enum8]
        public FairlightEqualizerFrequencyRange SupportedFrequencyRanges { get; set; }

        [Serialize(5), Enum8]
        public FairlightEqualizerFrequencyRange FrequencyRange { get; set; }
        
        [Serialize(8), UInt32Range(30, 21700)]
        public uint Frequency { get; set; }
        [Serialize(12), Int32D(100, -2000, 2000)]
        public double Gain { get; set; }
        [Serialize(16), Int16D(100, 30, 1030)]
        public double QFactor { get; set; }
    }
}