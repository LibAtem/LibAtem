using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.Audio;
using LibAtem.Serialization;

namespace LibAtem.Commands.Audio
{
    [CommandName("RAMP", 8), NoCommandId]
    public class AudioMixerResetPeaksCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            All = 1 << 0,
            Input = 1 << 1,
            Master = 1 << 2,
            Monitor = 1 << 3,
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }

        [Serialize(2), Enum16]
        public AudioSource Source { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Input))
                yield return new AudioMixerInputResetPeaksMacroOp { Input = Source };
            if (Mask.HasFlag(MaskFlags.Master))
                yield return new AudioMixerMasterOutResetPeaksMacroOp();
        }
    }
}