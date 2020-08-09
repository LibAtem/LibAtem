using System;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio.Fairlight
{
    [CommandName("RMOE", CommandDirection.ToServer, 4), NoCommandId]
    public class FairlightMixerMasterEqualizerResetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Equalizer = 1,
            Band = 2,
        }
        
        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }

        [Serialize(1), Bool]
        public bool Equalizer => Mask.HasFlag(MaskFlags.Equalizer);

        [Serialize(2), UInt8]
        public uint Band { get; set; }
    }
}