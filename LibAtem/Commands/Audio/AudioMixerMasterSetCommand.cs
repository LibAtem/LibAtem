using System;
using System.Collections.Generic;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.Audio;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("CAMM", 8), NoCommandId]
    public class AudioMixerMasterSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Gain = 1 << 0,
            Balance = 1 << 1,
            FollowFadeToBlack = 1 << 2,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [Serialize(2), Decibels]
        public double Gain { get; set; }
        [Serialize(4), Int16D(200, -10000, 10000)]
        public double Balance { get; set; }
        [Serialize(6), Bool]
        public bool FollowFadeToBlack { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Gain))
                yield return new AudioMixerMasterOutGainMacroOp {Gain = Gain};
            if (Mask.HasFlag(MaskFlags.Balance))
                yield return new AudioMixerMasterOutBalanceMacroOp {Balance = Balance};
            if (Mask.HasFlag(MaskFlags.FollowFadeToBlack))
                yield return new AudioMixerMasterOutFollowFadeToBlackMixEffectBlock1MacroOp {Follow = FollowFadeToBlack };
        }
    }
}