using System;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Transition;
using LibAtem.Serialization;
using System.Collections.Generic;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTTp", 4)]
    public class TransitionPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            Style = 1 << 0,
            Selection = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(2), Enum8]
        public TStyle Style { get; set; }
        [Serialize(3), Enum8]
        public TransitionLayer Selection { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps()
        {
            if (Mask.HasFlag(MaskFlags.Style))
                yield return new TransitionStyleMacroOp()
                {
                    Index = Index,
                    Style = Style,
                };

            if (Mask.HasFlag(MaskFlags.Selection))
                yield return new TransitionSourceMacroOp()
                {
                    Index = Index,
                    Source = Selection,
                };
        }
    }
}