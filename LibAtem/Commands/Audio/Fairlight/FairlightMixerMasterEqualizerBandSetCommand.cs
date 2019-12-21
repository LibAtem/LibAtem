using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("CMBP", CommandDirection.ToServer, 20)]
    public class FairlightMixerMasterEqualizerBandSetCommand : SerializableCommandBase
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
        [Serialize(1), UInt8Range(0, 5)]
        public uint Band { get; set; }
        [Serialize(2), Bool]
        public bool BandEnabled { get; set; }
        [Serialize(3), Enum8]
        public FairlightEqualizerBandShape Shape { get; set; }
        [Serialize(4), Enum8]
        public FairlightEqualizerFrequencyRange FrequencyRange { get; set; }
        [Serialize(8), UInt32Range(30, 21700)]
        public uint Frequency { get; set; }
        [Serialize(12), Int32D(100, -2000, 2000)]
        public double Gain { get; set; }
        [Serialize(16), Int16D(100, 30, 1030)]
        public double QFactor { get; set; }
    }
}