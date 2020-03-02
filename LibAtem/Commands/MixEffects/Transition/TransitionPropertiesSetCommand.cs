using System;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Transition;
using LibAtem.Serialization;
using System.Collections.Generic;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTTp", CommandDirection.ToServer, 4)]
    public class TransitionPropertiesSetCommand : SerializableCommandBase
    {
        [Flags]
        public enum MaskFlags
        {
            NextStyle = 1 << 0,
            NextSelection = 1 << 1,
        }

        [Serialize(0), Enum8]
        public MaskFlags Mask { get; set; }
        [CommandId]
        [Serialize(1), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(2), Enum8]
        public TransitionStyle NextStyle { get; set; }
        [Serialize(3), Enum8]
        public TransitionLayer NextSelection { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            if (Mask.HasFlag(MaskFlags.NextStyle))
                yield return new TransitionStyleMacroOp()
                {
                    Index = Index,
                    Style = NextStyle,
                };

            if (Mask.HasFlag(MaskFlags.NextSelection))
                yield return new TransitionSourceMacroOp()
                {
                    Index = Index,
                    Source = NextSelection,
                };
        }
    }
}