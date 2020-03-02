using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Wipe
{
    [MacroOperation(MacroOperationType.TransitionWipeAndDVEFlipFlop, 8)]
    public class TransitionWipeAndDVEFlipFlopMacroOp : MixEffectMacroOpBase
    {
        [Serialize(5), Bool]
        [MacroField("FlipFlop")]
        public bool FlipFlop { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionWipeSetCommand
            {
                Mask = TransitionWipeSetCommand.MaskFlags.FlipFlop,
                Index = Index,
                FlipFlop = FlipFlop,
            };
        }
    }
}