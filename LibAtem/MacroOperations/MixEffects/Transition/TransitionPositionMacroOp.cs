using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionPosition, 12)]
    public class TransitionPositionMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Position")]
        public double Position { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionPositionSetCommand()
            {
                Index = Index,
                HandlePosition = Position,
            };
        }
    }
}