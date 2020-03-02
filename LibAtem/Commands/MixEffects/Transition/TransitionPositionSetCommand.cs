using System.Collections.Generic;
using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.MacroOperations.MixEffects.Transition;
using LibAtem.Serialization;

namespace LibAtem.Commands.MixEffects.Transition
{
    [CommandName("CTPs", CommandDirection.ToServer, 4)]
    public class TransitionPositionSetCommand : SerializableCommandBase
    {
        [CommandId]
        [Serialize(0), Enum8]
        public MixEffectBlockId Index { get; set; }
        [Serialize(2), UInt16D(10000, 0, 9999)]
        public double HandlePosition { get; set; }

        public override IEnumerable<MacroOpBase> ToMacroOps(ProtocolVersion version)
        {
            yield return new TransitionPositionMacroOp
            {
                Index = Index,
                Position = HandlePosition,
            };
        }
    }
}