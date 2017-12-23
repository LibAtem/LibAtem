using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition.Wipe
{
    [MacroOperation(MacroOperationType.TransitionWipeSymmetry, 12)]
    public class TransitionWipeSymmetryMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), UInt32DScale]
        [MacroField("Symmetry")]
        public double Symmetry { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionWipeSetCommand
            {
                Mask = TransitionWipeSetCommand.MaskFlags.Symmetry,
                Index = Index,
                Symmetry = Symmetry,
            };
        }
    }
}