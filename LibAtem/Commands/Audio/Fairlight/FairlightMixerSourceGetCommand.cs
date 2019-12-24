using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("FASP", CommandDirection.ToClient, 52)]
    public class FairlightMixerSourceGetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum16]
        public AudioSource Index { get; set; }
        
        [CommandId]
        [Serialize(8), Int64]
        public long SourceId { get; set; }

        [Serialize(17), UInt8]
        public uint MaxFramesDelay { get; set; }
        [Serialize(18), UInt8]
        public uint FramesDelay { get; set; }

        [Serialize(20), Int32D(100, -10000, 600, true)]
        public double Gain { get; set; }

        [Serialize(29), Bool]
        public bool EqualizerEnabled { get; set; }
        [Serialize(32), Int32D(100, -2000, 2000)]
        public double EqualizerGain { get; set; }
        [Serialize(36), Int32D(100, 0, 2000)]
        public double MakeUpGain { get; set; }
        [Serialize(40), Int16D(100, -10000, 10000)]
        public double Balance { get; set; }
        [Serialize(44), Int32D(100, -10000, 1000, true)]
        public double FaderGain { get; set; }

        [Serialize(48), Enum8]
        public FairlightAudioMixOption SupportedMixOptions { get; set; }
        [Serialize(49), Enum8]
        public FairlightAudioMixOption MixOption { get; set; }
    }
}