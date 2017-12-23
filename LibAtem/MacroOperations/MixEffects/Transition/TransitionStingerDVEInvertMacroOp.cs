using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Transition;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.MacroOperations.MixEffects.Transition
{
    [MacroOperation(MacroOperationType.TransitionStingerDVEInvert, 8)]
    public class TransitionStingerDVEInvertMacroOp : MixEffectMacroOpBase
    {
        [Serialize(6), Bool]
        [MacroField("Invert")]
        public bool Invert { get; set; }

        public override ICommand ToCommand()
        {
            return new TransitionStingerSetCommand
            {
                Mask = TransitionStingerSetCommand.MaskFlags.Invert,
                Index = Index,
                Invert = Invert,
            };
        }
    }
}