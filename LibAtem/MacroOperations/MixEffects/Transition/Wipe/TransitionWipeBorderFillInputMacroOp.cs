using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Wipe
{
    [MacroOperation(MacroOperationType.TransitionWipeBorderFillInput, 8)]
    public class TransitionWipeBorderFillInputMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Input { get; set; }

        public override ICommand ToCommand(ProtocolVersion version)
        {
            return new TransitionWipeSetCommand
            {
                Mask = TransitionWipeSetCommand.MaskFlags.BorderInput,
                Index = Index,
                BorderInput = Input,
            };
        }
    }
}