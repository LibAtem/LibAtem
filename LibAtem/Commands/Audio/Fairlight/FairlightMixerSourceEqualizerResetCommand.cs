using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("RICE", CommandDirection.ToServer, 20)]
    public class FairlightMixerSourceEqualizerResetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Equalizer = 1,
            Band = 2,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        
        [CommandId]
        [Serialize(2), Enum16]
        public AudioSource Index { get; set; }
        [CommandId]
        [Serialize(8), Int64]
        public long SourceId { get; set; }

        [Serialize(16), Bool]
        public bool Equalizer => Mask.HasFlag(MaskFlags.Equalizer);


        [Serialize(17), UInt8]
        public uint Band { get; set; }

    }
}