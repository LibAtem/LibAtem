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
            // Unknown = 1 << 0, // Possibly ResetAll?
            Input = 1 << 1,
            Master = 1 << 2,
            // Monitor?
        }

        [Serialize(0), Enum16]
        public MaskFlags Mask { get; set; }

        [Serialize(2), Enum16]
        public AudioSource Source { get; set; }

        [Serialize(4), Bool]
        public bool Master { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Input))
                yield return new AudioMixerInputResetPeaksMacroOp { Input = Source };
            if (Mask.HasFlag(MaskFlags.Master))
                yield return new AudioMixerMasterOutResetPeaksMacroOp();
        }
    }
}