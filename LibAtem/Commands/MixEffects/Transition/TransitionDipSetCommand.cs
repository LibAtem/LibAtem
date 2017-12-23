using System;
using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Transition.Dip;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTDp", 8)]
    public class TransitionDipSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Rate = 1 << 0,
            Input = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(2), UInt8Range(0, 250)]
        public uint Rate { get; set; }
        [Serialize(4), Enum16]
        public VideoSource Input { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Rate))
                yield return new TransitionDipRateMacroOp() {Index = Index, Rate = Rate};

            if (Mask.HasFlag(MaskFlags.Input))
                yield return new TransitionDipInputMacroOp{Index = Index,Input = Input};
        }
    }
}