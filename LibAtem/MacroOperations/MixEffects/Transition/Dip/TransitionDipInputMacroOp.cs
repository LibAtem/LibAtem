using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Dip
{
    [MacroOperation(MacroOperationType.TransitionDipInput, 8)]
    public class TransitionDipInputMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Enum16]
        [MacroField("Input")]
        public VideoSource Input { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionDipSetCommand()
            {
                Mask = TransitionDipSetCommand.MaskFlags.Input,
                Index = Index,
                Input = Input,
            };
        }
    }
}