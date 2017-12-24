using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Stinger
{
    [MacroOperation(MacroOperationType.TransitionDVECutInput, 8)]
    public class TransitionDVECutInputMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Input { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionDVESetCommand
            {
                Mask = TransitionDVESetCommand.MaskFlags.KeySource,
                Index = Index,
                KeySource = Input,
            };
        }
    }
}