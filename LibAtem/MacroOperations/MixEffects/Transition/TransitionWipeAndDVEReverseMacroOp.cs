using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionWipeAndDVEReverse, 8)]
    public class TransitionWipeAndDVEReverseMacroOp : MixEffectMacroOpBase
    {
        [Serialize(5), Bool]
        [MacroField("Reverse")]
        public bool ReverseDirection { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionWipeSetCommand
            {
                Mask = TransitionWipeSetCommand.MaskFlags.ReverseDirection,
                Index = Index,
                ReverseDirection = ReverseDirection,
            };
        }
    }
}